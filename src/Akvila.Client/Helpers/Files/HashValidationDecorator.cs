using System.Collections.Concurrent;
using System.Security.Cryptography;
using Akvila.Web.Api.Dto.Files;
using Akvila.Web.Api.Dto.Profile;

namespace Akvila.Client.Helpers.Files;

public class HashValidationDecorator : IFileUpdateHandler {
    private readonly IFileUpdateHandler _handler;

    public HashValidationDecorator(IFileUpdateHandler handler) {
        _handler = handler;
    }

    public async Task<FileValidationResult> ValidateFilesAsync(ProfileReadInfoDto profileInfo, string rootDirectory) {
        var result = await _handler.ValidateFilesAsync(profileInfo, rootDirectory);
        var filesToUpdate = new ConcurrentBag<ProfileFileReadDto>();
        var filesToDelete = new ConcurrentDictionary<string, ProfileFileReadDto>(
            result.FilesToDelete.ToDictionary(
                f => SystemIoProcedures.NormalizePath(f.Directory),
                f => f
            )
        );
        var files = result.FilesToUpdate.ToList();

        await Task.WhenAll(files.Select(async serverFile => {

            filesToDelete.TryGetValue(SystemIoProcedures.NormalizePath(serverFile.Directory), out var localFile);

            if (localFile is null) {
                var localPath = Path.Combine(rootDirectory, SystemIoProcedures.NormalizePath(serverFile.Directory));

                if (File.Exists(localPath)) {
                    var fileInfo = new FileInfo(localPath);
                    // First, we check the size
                    if (fileInfo.Length == serverFile.Size) {
                        // Size match - check the hash
                        localFile = new ProfileFileReadDto {
                            Name = serverFile.Name,
                            Directory = serverFile.Directory,
                            Size = fileInfo.Length,
                        };
                    }
                    else {
                        // Sizes do not match - immediately add to the list for updating
                        filesToUpdate.Add(serverFile);
                        return;
                    }
                }
            }

            if (localFile == null) {
                // File is not available locally - need to download
                filesToUpdate.Add(serverFile);
            }
            else if (localFile.Size == serverFile.Size) {
                // Size match - check the hash
                using var algorithm = SHA1.Create();
                var localPath = Path.Combine(rootDirectory, SystemIoProcedures.NormalizePath(serverFile.Directory));
                if (!localPath.StartsWith(Path.Combine(rootDirectory, "assets")) &&
                    SystemHelper.CalculateFileHash(localPath, algorithm) != serverFile.Hash) {
                    filesToUpdate.Add(serverFile);
                    filesToDelete.TryRemove(SystemIoProcedures.NormalizePath(localFile.Directory), out _);
                }
                else {
                    // The file is up to date - remove it from the deletion list
                    filesToDelete.TryRemove(SystemIoProcedures.NormalizePath(localFile.Directory), out _);
                }
            }
            else {
                // Sizes don't match - need to update
                filesToUpdate.Add(serverFile);
                filesToDelete.TryRemove(SystemIoProcedures.NormalizePath(localFile.Directory), out _);
            }
        }));

        result.FilesToUpdate = filesToUpdate;
        result.FilesToDelete = filesToDelete.Values;
        return result;
    }
}
