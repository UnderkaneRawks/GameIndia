namespace GameIndiaApi.Models
{
    public class RawgStoresResponse
    {
        public List<RawgStore> Results { get; set; } = new List<RawgStore>();
    }

    public class RawgStore
    {
        public int Id { get; set; } // Store ID
        public string Name { get; set; } = string.Empty; // Name of the store
        public string Domain { get; set; } = string.Empty; // Store domain (e.g., "store.steampowered.com")
    }
}