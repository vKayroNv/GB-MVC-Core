using System.Text.Json.Serialization;

namespace ShopParser.Models.DNSModels
{
    internal class Offers
    {
        [JsonPropertyName("@type")]
        public string Type { get; set; }
        public string url { get; set; }
        public string availability { get; set; }
        public int price { get; set; }
        public string priceCurrency { get; set; }
    }
}
