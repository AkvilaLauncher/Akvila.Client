using AkvilaCore.Interfaces.Enums;

namespace Akvila.Web.Api.Dto.Integration;

public class AuthTypeReadDto {
    public AuthGeneralType AuthType { get; set; } = AuthGeneralType.Undefined;
    public string Data { get; set; } = string.Empty;
}
