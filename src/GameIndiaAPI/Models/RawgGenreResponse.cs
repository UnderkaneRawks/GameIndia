using System.Collections.Generic;

namespace GameIndiaApi.Models
{
    /// <summary>
    /// Represents the response from RAWG's genres endpoint.
    /// </summary>
    public class RawgGenresResponse
    {
        public List<RawgGenre> Results { get; set; } = new List<RawgGenre>();
    }

    public class RawgGenre
    {
        public string Name { get; set; } = string.Empty; // The name of the genre
    }
}