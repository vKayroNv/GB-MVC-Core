using ShopParser.Models.EldoradoModels;

namespace ShopParser.Models
{
    internal class EldoradoModel
    {
        public int OldPrice { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public int Weight { get; set; }
        public int ItemId { get; set; }
        public List<int> CategoryIds { get; set; }
        public object Regions { get; set; }
        public Params Params { get; set; }
        public object Size { get; set; }
        public object Color { get; set; }
        public object Author { get; set; }
        public object Barcode { get; set; }
        public object BuyUrl { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public object TypePrefix { get; set; }
        public string Vendor { get; set; }
        public object Algorithm { get; set; }
        public object PreviousPrice { get; set; }
        public string PictureUrl { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public object GroupId { get; set; }

        public ViewModel ToViewModel()
        {
            return new ViewModel()
            {
                Name = Name,
                Price = Price,
                ImageUrl = new() { PictureUrl }
            };
        }
    }
}