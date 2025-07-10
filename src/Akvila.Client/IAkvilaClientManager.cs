using System.Diagnostics;
using System.Runtime.InteropServices;
using Akvila.Web.Api.Dto.Files;
using Akvila.Web.Api.Dto.Integration;
using Akvila.Web.Api.Dto.Messages;
using Akvila.Web.Api.Dto.Mods;
using Akvila.Web.Api.Dto.News;
using Akvila.Web.Api.Dto.Profile;
using AkvilaCore.Interfaces.Enums;
using AkvilaCore.Interfaces.Storage;
using AkvilaCore.Interfaces.User;

namespace Akvila.Client;

using IUser = Models.IUser;

public interface IAkvilaClientManager : IDisposable {
    IObservable<int> ProgressChanged { get; }
    IObservable<bool> ProfilesChanges { get; }
    public string ProjectName { get; }
    IObservable<int> MaxFileCount { get; }
    IObservable<int> LoadedFilesCount { get; }
    string InstallationDirectory { get; }
    bool SkipUpdate { get; set; }
    Task<ResponseMessage<List<ProfileReadDto>>> GetProfiles();
    Task<ResponseMessage<List<ModsDetailsInfoDto>>> GetOptionalModsInfo(string accessToken);
    Task<ResponseMessage<List<ProfileReadDto>>> GetProfiles(string accessToken);
    Task<ResponseMessage<ProfileReadInfoDto?>?> GetProfileInfo(ProfileCreateInfoDto profileDto);
    public Task<Process> GetProcess(ProfileReadInfoDto profileDto, OsType osType);
    Task DownloadNotInstalledFiles(ProfileReadInfoDto profileInfo, CancellationToken cancellationToken);
    Task<(IUser User, string Message, IEnumerable<string> Details)> Auth(string login, string password, string hwid);
    Task<(IUser User, string Message, IEnumerable<string> Details)> Auth(string accessToken);
    Task ClearFiles(ProfileReadInfoDto profile);
    Task LoadDiscordRpc();
    Task UpdateDiscordRpcState(string state);
    Task<IVersionFile?> GetActualVersion(OsType osType, Architecture osArch);

    Task UpdateCurrentLauncher((IVersionFile? ActualVersion, bool IsActuallVersion) versionInfo, OsType osType,
                               string originalFileName);

    Task OpenServerConnection(IUser user);
    void ChangeInstallationFolder(string installationDirectory);
    Task<IPlayerTexture?> GetTexturesByName(string userName);
    Task<ResponseMessage<List<ModReadDto>>> GetOptionalMods(string profileName, string accessToken);
    bool ToggleOptionalMod(string path, bool isEnebled);

    Task DownloadFiles(ProfileFileReadDto[] profileInfo,
                       CancellationToken cancellationToken = default);

    Task<ResponseMessage<List<NewsReadDto>>> GetNews();

    Task<ResponseMessage<AuthTypeReadDto>> GetAuthType();
    string GetTextureUrl();
}
