using System.Collections.Generic;

namespace Akvila.Web.Api.Dto.Mods;

public class ExtendedModInfoReadDto : ExtendedModReadDto {
    public IReadOnlyCollection<ModVersionDto> Versions { get; set; }
}
