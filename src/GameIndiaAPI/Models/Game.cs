namespace GameIndiaApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public string? Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Upcoming { get; set; }
        public bool Recommended { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
    }
}
