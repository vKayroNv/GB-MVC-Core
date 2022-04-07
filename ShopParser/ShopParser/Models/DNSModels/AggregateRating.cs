using System.Text.Json.Serialization;

namespace ShopParser.Models.DNSModels
{
    internal class AggregateRating
    {
        [JsonPropertyName("@type")]
        public string Type { get; set; }
        public double ratingValue { get; set; }
        public int worstRating { get; set; }
        public int bestRating { get; set; }
        public int reviewCount { get; set; }
    }
}
