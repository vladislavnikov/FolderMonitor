using System.Text.Json.Serialization;

namespace FolderMonitor.Model
{
    public class AuthResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("mfa_trust_device_token")]
        public string MfaTrustDeviceToken { get; set; }

        [JsonPropertyName("mfa_trust_device_token_expire_date")]
        public string MfaTrustDeviceTokenExpireDate { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
