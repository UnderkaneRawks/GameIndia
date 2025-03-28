using GameIndiaApi.Models;
using GameIndiaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameIndiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly RawgApiService _rawgApiService;

        public GamesController(RawgApiService rawgApiService)
        {
            _rawgApiService = rawgApiService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchGames(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Game name cannot be empty.");
            }

            var rawJson = await _rawgApiService.GetGamesAsync(name);

            if (string.IsNullOrEmpty(rawJson))
            {
                return NotFound($"No games found for '{name}'.");
            }

            try
            {
                var rawgResponse = JsonSerializer.Deserialize<RawgGameResponse>(rawJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var games = new List<Game>();

                foreach (var rawgGame in rawgResponse?.Results ?? new List<RawgGame>())
                {
                    // Fetch detailed game data for each result
                    var detailedGame = await _rawgApiService.GetGameDetailsAsync(rawgGame.Id);

                    games.Add(new Game
                    {
                        Id = rawgGame.Id,
                        Name = rawgGame.Name,
                        Slug = rawgGame.Slug,
                        Genre = rawgGame.Genres != null ? string.Join(", ", rawgGame.Genres.Select(g => g.Name)) : "Unknown",
                        Developer = detailedGame?.Developers != null && detailedGame.Developers.Any()
                            ? string.Join(", ", detailedGame.Developers.Select(d => d.Name))
                            : "Unknown",
                        ReleaseDate = DateTime.TryParse(rawgGame.Released, out var releaseDate) ? releaseDate : (DateTime?)null,
                        BackgroundImage = rawgGame.BackgroundImage,
                        MetacriticScore = rawgGame.Metacritic,
                        Description = detailedGame?.Description ?? "No description available"
                    });
                }

                return Ok(games);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the RAWG API response.");
            }
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _rawgApiService.GetGenresAsync();

            if (genres == null || !genres.Any())
            {
                return NotFound("No genres found.");
            }

            return Ok(genres);
        }

        [HttpGet("stores")]
        public async Task<IActionResult> GetStores()
        {
            var stores = await _rawgApiService.GetStoresAsync();

            if (stores == null || !stores.Any())
            {
                return NotFound("No stores found.");
            }

            return Ok(stores);
        }
    }
}