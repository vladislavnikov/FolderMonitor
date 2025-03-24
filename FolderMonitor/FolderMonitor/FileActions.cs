using FolderMonitor.Constants;
using System.Net.Http.Headers;

namespace FolderMonitor
{
    /// <summary>
    /// Provides methods for performing file actions, such as uploading files to a remote repo.
    /// </summary>
    public class FileActions
    {
        private readonly HttpClient _httpClient;

        public FileActions(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Asynchronously uploads a file to the specified endpoint.
        /// </summary>
        /// <param name="filePath">The path to the file to upload.</param>
        /// <param name="homeFolderId">The optional ID of the home folder to upload to.</param>
        /// <param name="fileName">The desired name of the file on the server.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task UploadFileAsync(string filePath, int? homeFolderId, string fileName)
        {
            using var content = new MultipartFormDataContent();
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            content.Add(streamContent, "file", fileName);

            var response = await _httpClient.PostAsync(Endpoints.UPLOAD(homeFolderId), content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Uploaded: {fileName}");
            }
            else
            {
                Console.WriteLine($"Failed to upload {fileName}. Status: {response.StatusCode}");
            }
        }
    }
}
