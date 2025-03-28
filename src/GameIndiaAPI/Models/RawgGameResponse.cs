using System.Collections.Generic;

namespace GameIndiaApi.Models
{
    /// <summary>
    /// Represents the response from the RAWG API's games endpoint.
    /// </summary>
    public class RawgGameResponse
    {
        public int Count { get; set; } // Total number of games matching the query
        public List<RawgGame> Results { get; set; } = new List<RawgGame>(); // List of matching games

    }

    public class RawgGame
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Released { get; set; } = string.Empty;
        public int? Metacritic { get; set; }
        public string? BackgroundImage { get; set; }
        public List<RawgGenre>? Genres { get; set; } = new List<RawgGenre>();
        public List<RawgDeveloper>? Developers { get; set; } = new List<RawgDeveloper>();

        // Add this field for detailed information
        public string? Description { get; set; } = null;
    }

    public class RawgDeveloper
    {
        public string Name { get; set; } = string.Empty; // Name of the developer
    }
}