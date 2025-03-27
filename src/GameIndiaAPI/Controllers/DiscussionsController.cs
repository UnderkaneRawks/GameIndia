using Microsoft.AspNetCore.Mvc;
using GameIndiaApi.Models;

namespace GameIndiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionsController : ControllerBase
    {
        private static List<DiscussionThread> threads = new List<DiscussionThread>();

        // GET: api/discussions?gameId=1
        [HttpGet]
        public IActionResult GetDiscussionsByGameId(int? gameId = null)
        {
            var filteredThreads = threads.Where(t => !gameId.HasValue || t.GameId == gameId).ToList();
            if (!filteredThreads.Any())
                return NotFound(gameId.HasValue
                    ? $"No discussion threads found for game with ID {gameId}."
                    : "No discussion threads found.");

            return Ok(filteredThreads);
        }

        // POST: api/discussions
        [HttpPost]
        public IActionResult AddDiscussionThread([FromBody] DiscussionThread thread)
        {
            if (string.IsNullOrWhiteSpace(thread.Title))
                return BadRequest("Title cannot be empty.");

            threads.Add(thread);
            return CreatedAtAction(nameof(GetDiscussionsByGameId), new { gameId = thread.GameId }, thread);
        }

        // POST: api/discussions/{threadId}/posts
        [HttpPost("{threadId}/posts")]
        public IActionResult AddDiscussionPost(Guid threadId, [FromBody] DiscussionPost post)
        {
            var thread = threads.FirstOrDefault(t => t.ThreadId == threadId);
            if (thread == null)
                return NotFound($"Thread with ID {threadId} not found.");

            if (string.IsNullOrWhiteSpace(post.Content))
                return BadRequest("Content cannot be empty.");

            thread.Posts.Add(post);
            return CreatedAtAction(nameof(GetDiscussionsByGameId), new { gameId = thread.GameId }, post);
        }
    }
}