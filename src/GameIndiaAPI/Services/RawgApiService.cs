using GameIndiaApi.Models;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameIndiaApi.Services
{
    public class RawgApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.rawg.io/api";
        private const string ApiKey = "1a42effd3c1e4c3e804a69a8362cdf6c"; // Replace with your actual API key

        public RawgApiService(HttpClient httpClient)
        {
            // Force TLS 1.2 (or higher)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _httpClient = httpClient;
        }

        public async Task<string?> GetGamesAsync(string searchQuery)
        {
            var url = $"{BaseUrl}/games?search={searchQuery}&key={ApiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<RawgGame?> GetGameDetailsAsync(int gameId)
        {
            var url = $"{BaseUrl}/games/{gameId}?key={ApiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null; // Return null if the request fails
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RawgGame>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<List<string>> GetGenresAsync()
        {
            var url = $"{BaseUrl}/genres?key={ApiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<string>(); // Return an empty list if the request fails
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var rawgGenres = JsonSerializer.Deserialize<RawgGenresResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return rawgGenres?.Results.Select(g => g.Name).ToList() ?? new List<string>();
        }

        public async Task<List<RawgStore>> GetStoresAsync()
        {
            var url = $"{BaseUrl}/stores?key={ApiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<RawgStore>(); // Return empty list if API call fails
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var rawgStores = JsonSerializer.Deserialize<RawgStoresResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return rawgStores?.Results ?? new List<RawgStore>();
        }
    }
}