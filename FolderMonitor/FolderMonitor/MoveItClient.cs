using FolderMonitor.Constants;
using FolderMonitor.Model;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FolderMonitor
{
    public class MoveItClient
    {
        private readonly HttpClient _httpClient;
        private string _accessToken;
        private string _refreshToken;
        private DateTime _tokenExpiry;

        public MoveItClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Endpoints.BASE_URL) };
        }

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
