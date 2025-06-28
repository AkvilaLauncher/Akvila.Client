using Newtonsoft.Json;

namespace Akvila.Web.Api.Dto.Minecraft.AuthLib;

public class ProfileProperties {
    [JsonProperty("name")] public string Name { get; } = "textures";

    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("signature")]
    public string Signature { get; set; } =
        "Cg=="; //Not used because this is used with signatures(certificates)
}
