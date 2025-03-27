using Microsoft.AspNetCore.Mvc;
using GameIndiaApi.Models;

namespace GameIndiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugReportsController : ControllerBase
    {
        private static List<BugReport> bugReports = new List<BugReport>();

        // GET: api/bugreports?gameId=1
        [HttpGet]
        public IActionResult GetBugReports(int? gameId = null)
        {
            var filtered = bugReports.Where(b => !gameId.HasValue || b.GameId == gameId).ToList();
            if (!filtered.Any())
                return NotFound(gameId.HasValue
                    ? $"No bug reports found for game with ID {gameId}."
                    : "No bug reports found.");

            return Ok(filtered);
        }

        // POST: api/bugreports
        [HttpPost]
        public IActionResult AddBugReport([FromBody] BugReport bugReport)
        {
            if (string.IsNullOrWhiteSpace(bugReport.Description))
                return BadRequest("Description cannot be empty.");

            bugReport.Id = bugReports.Count + 1; // Simulate auto-increment
            bugReports.Add(bugReport);

            return CreatedAtAction(nameof(GetBugReports), new { gameId = bugReport.GameId }, bugReport);
        }
    }
}