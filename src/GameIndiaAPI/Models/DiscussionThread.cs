namespace GameIndiaApi.Models
{
    public class DiscussionThread
    {
        public Guid ThreadId { get; set; } = Guid.NewGuid();
        public int? GameId { get; set; }         // Nullable for general discussions
        public string Title { get; set; } = string.Empty;
        public string CreatorId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<DiscussionPost> Posts { get; set; } = new List<DiscussionPost>();
    }
}