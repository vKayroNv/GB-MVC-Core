using ShopParser.Models.SvyaznoyModels;

namespace ShopParser.Models
{
    internal class SvyaznoyModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public string preview_image { get; set; }
        public List<string> articles { get; set; }
        public string full_name { get; set; }
        public Brand brand { get; set; }
        public string image { get; set; }
        public Category category { get; set; }
        public Offer offer { get; set; }
        public int max_quantity { get; set; }
        public Attr attr { get; set; }
        public object special_offer { get; set; }
        public bool is_only_rtt_preorder { get; set; }
        public object text_for_product { get; set; }
        public bool is_consumed { get; set; }
        public List<object> supplier_offers { get; set; }
        public object vat { get; set; }

        public ViewModel ToViewModel()
        {
            return new ViewModel()
            {
                Name = full_name,
                Price = offer.price,
                ImageUrl = new() { image }
            };
        }
    }
}
