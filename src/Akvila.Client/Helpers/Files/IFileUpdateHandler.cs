using Akvila.Web.Api.Dto.Profile;

namespace Akvila.Client.Helpers.Files;

public interface IFileUpdateHandler {
    Task<FileValidationResult> ValidateFilesAsync(ProfileReadInfoDto profileInfo, string rootDirectory);
}
