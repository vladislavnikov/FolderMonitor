namespace FolderMonitor.Constants
{
    public  class Endpoints
    {
        public static readonly string BASE_URL = "https://testserver.moveitcloud.com";
        public static readonly string TOKEN = "/api/v1/token";
        public static readonly string USER = "/api/v1/users/self";
        public static string UPLOAD(int? folderId ) => $"/api/v1/folders/{folderId}/files";
    }
}
