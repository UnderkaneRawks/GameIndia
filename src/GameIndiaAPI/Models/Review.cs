namespace GameIndiaApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int GameId { get; set; }          // Links the review to a game
        public string? UserId { get; set; }     // Nullable for flexibility
        public string? Content { get; set; }    // Nullable, as some reviews might be brief
        public int Rating { get; set; }         // 1-5 star rating system
        public DateTime CreatedAt { get; set; }
    }
}