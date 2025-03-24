using FolderMonitor.Constants;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FolderMonitor
{
    public class FileActions
    {
        private readonly HttpClient _httpClient;

        public FileActions(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

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
