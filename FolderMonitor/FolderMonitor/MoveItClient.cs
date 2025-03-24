using FolderMonitor.Constants;
using FolderMonitor.Model;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FolderMonitor
{
    /// <summary>
    /// Client for interacting with the MOVEit Transfer API.
    /// </summary>
    public class MoveItClient
    {
        private readonly HttpClient _httpClient;
        private string _accessToken;
        private string _refreshToken;
        private DateTime _tokenExpiry;

        public HttpClient HttpClient => _httpClient;

        public MoveItClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Endpoints.BASE_URL) };
        }

        /// <summary>
        /// Authenticates the user with the MOVEit Transfer API.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if authentication is successful; otherwise, false.</returns>
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var requestBody = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            var response = await _httpClient.PostAsync(Endpoints.TOKEN, requestBody);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Authentication failed: {response.StatusCode}");
                return false;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<AuthResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (data?.AccessToken == null)
            {
                Console.WriteLine("Failed to retrieve access token.");
                return false;
            }

            _accessToken = data.AccessToken;
            _refreshToken = data.RefreshToken;
            _tokenExpiry = DateTime.UtcNow.AddSeconds(data.ExpiresIn - 60);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            Console.WriteLine("Authentication successful!");
            return true;
        }

        /// <summary>
        /// Retrieves the user's home folder ID from the MOVEit Transfer API.
        /// </summary>
        /// <returns>The home folder ID, or null if retrieval fails.</returns>
        public async Task<int?> GetHomeFolderIdAsync()
        {
            var response = await _httpClient.GetAsync(Endpoints.USER);

            if (!response.IsSuccessStatusCode)
                return null;


            var jsonResponse = await response.Content.ReadAsStringAsync();
            var userData = JsonSerializer.Deserialize<UserResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return userData?.HomeFolderID;
        }
    }
}
