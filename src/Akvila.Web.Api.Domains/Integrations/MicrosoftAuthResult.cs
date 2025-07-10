using System.Collections.Generic;
using Newtonsoft.Json;

namespace Akvila.Web.Api.Domains.Integrations;

public class MicrosoftAuthResult {
    [JsonProperty("IssueInstant")] public string IssueInstant { get; set; }

    [JsonProperty("NotAfter")] public string NotAfter { get; set; }

    [JsonProperty("Token")] public string Token { get; set; }

    [JsonProperty("DisplayClaims")] public DisplayClaims DisplayClaims { get; set; }
}

public class DisplayClaims {
    [JsonProperty("xui")] public List<Xui> Xui { get; set; }
}

public class Xui {
    [JsonProperty("uhs")] public string Uhs { get; set; }
}

public class MicrosoftDeviceCode {
    [JsonProperty("user_code")] public string UserCode { get; set; }

    [JsonProperty("device_code")] public string DeviceCode { get; set; }

    [JsonProperty("verification_uri")] public string VerificationUri { get; set; }

    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }

    [JsonProperty("interval")] public int Interval { get; set; }

    [JsonProperty("message")] public string Message { get; set; }
}

public class MicrosoftDeviceToken {
    [JsonProperty("token_type")] public string TokenType { get; set; }

    [JsonProperty("scope")] public string Scope { get; set; }

    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }

    [JsonProperty("ext_expires_in")] public int ExtExpiresIn { get; set; }

    [JsonProperty("access_token")] public string AccessToken { get; set; }

    [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

    [JsonProperty("id_token")] public string IdToken { get; set; }
}

public class MicrosoftAuthError {
    [JsonProperty("Identity")] public string Identity { get; set; }

    [JsonProperty("XErr")] public uint XErr { get; set; }

    [JsonProperty("Message")] public string Message { get; set; }

    [JsonProperty("Redirect")] public string Redirect { get; set; }
}

public class MinecraftAuthResult {
    [JsonProperty("username")] public string Username { get; set; }

    [JsonProperty("roles")] public List<string> Roles { get; set; }

    [JsonProperty("access_token")] public string AccessToken { get; set; }

    [JsonProperty("token_type")] public string TokenType { get; set; }

    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }
}

public class MinecraftProfile {
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("skins")] public List<MinecraftSkin> Skins { get; set; }

    [JsonProperty("capes")] public List<MinecraftCape> Capes { get; set; }
}

public class MinecraftSkin {
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("state")] public string State { get; set; }

    [JsonProperty("url")] public string Url { get; set; }

    [JsonProperty("variant")] public string Variant { get; set; }

    [JsonProperty("alias")] public string Alias { get; set; }
}

public class MinecraftCape {
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("state")] public string State { get; set; }

    [JsonProperty("url")] public string Url { get; set; }

    [JsonProperty("alias")] public string Alias { get; set; }
}

public class MinecraftProfileError {
    [JsonProperty("path")] public string Path { get; set; }

    [JsonProperty("error")] public string Error { get; set; }

    [JsonProperty("errorMessage")] public string ErrorMessage { get; set; }
}
