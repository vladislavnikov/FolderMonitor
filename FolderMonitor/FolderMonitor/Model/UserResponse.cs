namespace FolderMonitor.Model
{
    using System.Text.Json.Serialization;

    public class UserResponse
    {
        [JsonPropertyName("emailFormat")]
        public string EmailFormat { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("statusNote")]
        public string StatusNote { get; set; }

        [JsonPropertyName("passwordChangeStamp")]
        public string PasswordChangeStamp { get; set; }

        [JsonPropertyName("receivesNotification")]
        public string ReceivesNotification { get; set; }

        [JsonPropertyName("forceChangePassword")]
        public bool? ForceChangePassword { get; set; }

        [JsonPropertyName("folderQuota")]
        public int FolderQuota { get; set; }

        [JsonPropertyName("totalFileSize")]
        public int TotalFileSize { get; set; }

        [JsonPropertyName("authMethod")]
        public string AuthMethod { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("homeFolderID")]
        public int HomeFolderID { get; set; }

        [JsonPropertyName("defaultFolderID")]
        public int DefaultFolderID { get; set; }

        [JsonPropertyName("expirationPolicyID")]
        public int? ExpirationPolicyID { get; set; }

        [JsonPropertyName("displaySettings")]
        public DisplaySettings DisplaySettings { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("orgID")]
        public int OrgID { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("permission")]
        public string Permission { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("lastLoginStamp")]
        public string LastLoginStamp { get; set; }
    }

    public class DisplaySettings
    {
        [JsonPropertyName("userListPageSize")]
        public int UserListPageSize { get; set; }

        [JsonPropertyName("fileListPageSize")]
        public int FileListPageSize { get; set; }

        [JsonPropertyName("liveViewPageSize")]
        public int LiveViewPageSize { get; set; }
    }

}
