using System;

namespace GameIndiaApi.Models
{
    /// <summary>
    /// Represents a single game with relevant properties.
    /// </summary>
    public class Game
    {
        public int Id { get; set; } // Unique identifier for the game
        public string Name { get; set; } = string.Empty; // Title of the game
        public string? Slug { get; set; } // URL-friendly identifier
        public string? Genre { get; set; } // Comma-separated list of genres
        public string? Developer { get; set; } = "Unknown"; // Developer name(s), fallback to "Unknown"
        public DateTime? ReleaseDate { get; set; } // Release date, nullable if unknown
        public string? BackgroundImage { get; set; } // URL to the game's background image
        public int? MetacriticScore { get; set; } // Metacritic score, nullable if not available
        public string? Description { get; set; } // Game description
    }
}