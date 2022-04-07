using System.Text.Json.Serialization;

namespace ShopParser.Models.DNSModels
{
    internal class Data
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public Offers offers { get; set; }
        public AggregateRating aggregateRating { get; set; }
        public List<string> image { get; set; }
        public Brand brand { get; set; }
    }
}
