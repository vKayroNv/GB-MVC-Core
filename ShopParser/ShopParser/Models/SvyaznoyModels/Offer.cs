namespace ShopParser.Models.SvyaznoyModels
{
    internal class Offer
    {
        public int quantity { get; set; }
        public string quantity_zone { get; set; }
        public string quantity_store { get; set; }
        public object quantity_in_store { get; set; }
        public List<string> locations { get; set; }
        public int delivery_rate { get; set; }
        public int available { get; set; }
        public int preorder { get; set; }
        public int price { get; set; }
        public int price_old { get; set; }
        public string order_type { get; set; }
        public int location { get; set; }
        public bool is_only_third_party_vendor { get; set; }
    }
}
