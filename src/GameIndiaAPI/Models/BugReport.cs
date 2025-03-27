namespace GameIndiaApi.Models
{
    public class BugReport
    {
        public int Id { get; set; }
        public int? GameId { get; set; }         // Nullable for app-wide bugs
        public string? UserId { get; set; }     // Optional user identification
        public string Description { get; set; } = string.Empty; // Default to prevent null issues
        public bool IsCritical { get; set; }
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    }
}