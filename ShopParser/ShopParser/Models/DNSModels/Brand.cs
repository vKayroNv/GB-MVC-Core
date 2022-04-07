using System.Text.Json.Serialization;

namespace ShopParser.Models.DNSModels
{
    internal class Brand
    {
        [JsonPropertyName("@type")]
        public string Type { get; set; }
        public string name { get; set; }
    }
}
