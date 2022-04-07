using ShopParser.Models.DNSModels;

namespace ShopParser.Models
{
    internal class DNSModel
    {
        public bool result { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
        public List<object> errors { get; set; }

        public ViewModel ToViewModel()
        {
            return new ViewModel()
            {
                Name = data.name,
                Price = data.offers.price,
                ImageUrl = data.image
            };
        }
    }
}
