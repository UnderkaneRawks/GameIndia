using Microsoft.AspNetCore.Mvc;
using GameIndiaApi.Models;

namespace GameIndiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // For now, we are using an in-memory list of games.
        private static List<Game> games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Name = "Game 1",
                Genre = "RPG",
                Developer = "Indian Dev Studio",
                ReleaseDate = DateTime.Now.AddDays(-10),
                Upcoming = false,
                Recommended = true,
                Price = 599,
                DiscountedPrice = 499
            },
            new Game
            {
                Id = 2,
                Name = "Game 2",
                Genre = "Shooter",
                Developer = "Another Indian Dev Studio",
                ReleaseDate = DateTime.Now.AddDays(5),
                Upcoming = true,
                Recommended = false,
                Price = 999
            }
        };

        // GET: api/games
        [HttpGet]
        public IActionResult GetAllGames() => Ok(games);

        // GET: api/games/look-up/indian
        [HttpGet("look-up/indian")]
        public IActionResult GetIndianReleases()
        {
            var indianGames = games.Where(g => g.Developer != null && g.Developer.Contains("Indian", StringComparison.OrdinalIgnoreCase));
            return Ok(indianGames);
        }
    }
}