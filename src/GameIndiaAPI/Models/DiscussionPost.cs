namespace GameIndiaApi.Models
{
    public class DiscussionPost
    {
        public Guid PostId { get; set; } = Guid.NewGuid();
        public Guid ThreadId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }
}