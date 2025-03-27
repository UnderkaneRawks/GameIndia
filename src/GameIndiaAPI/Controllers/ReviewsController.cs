using Microsoft.AspNetCore.Mvc;
using GameIndiaApi.Models;

namespace GameIndiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private static List<Review> reviews = new List<Review>();

        // GET: api/reviews?gameId=1
        [HttpGet]
        public IActionResult GetReviewsByGameId(int gameId)
        {
            var gameReviews = reviews.Where(r => r.GameId == gameId).ToList();
            if (!gameReviews.Any())
                return NotFound($"No reviews found for game with ID {gameId}.");

            return Ok(gameReviews);
        }

        // POST: api/reviews
        [HttpPost]
        public IActionResult AddReview([FromBody] Review review)
        {
            if (string.IsNullOrWhiteSpace(review.Content))
                return BadRequest("Content cannot be empty.");

            review.Id = reviews.Count + 1; // Simulate auto-increment
            review.CreatedAt = DateTime.UtcNow;
            reviews.Add(review);

            return CreatedAtAction(nameof(GetReviewsByGameId), new { gameId = review.GameId }, review);
        }
    }
}