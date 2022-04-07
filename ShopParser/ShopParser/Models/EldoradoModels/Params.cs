using System.Text.Json.Serialization;

namespace ShopParser.Models.EldoradoModels
{
    internal class Params
    {
        public string reviews { get; set; }
        public string rating { get; set; }
        public string reviews_link { get; set; }
        public bool vitrina { get; set; }
        public string bonus { get; set; }
        public string cpu { get; set; }
        public string cores_number { get; set; }
        public string built_in_memory { get; set; }
        public string ram { get; set; }
        public string screen_resolution { get; set; }
        public string diagonal { get; set; }
        public string camera_resolution { get; set; }

        [JsonPropertyName("credit10/10/10")]
        public string Credit101010 { get; set; }

        [JsonPropertyName("online_paymet(crysis)")]
        public string OnlinePaymetCrysis { get; set; }

        [JsonPropertyName("taxi-delivery_13")]
        public string TaxiDelivery13 { get; set; }
        public string eyezon_telecom { get; set; }
        public string _5post_pvz_1 { get; set; }
    }
}