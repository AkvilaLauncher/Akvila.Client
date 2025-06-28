using Akvila.Web.Api.Dto.Files;

namespace Akvila.Client.Helpers.Files;

public class FileValidationResult {
    public IEnumerable<ProfileFileReadDto> FilesToUpdate { get; set; } = [];
    public IEnumerable<ProfileFileReadDto> FilesToDelete { get; set; } = [];
}
