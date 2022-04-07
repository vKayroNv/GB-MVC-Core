namespace ShopParser.Models
{
    public sealed class ViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<string> ImageUrl { get; set; }

        public override string ToString()
        {
            string images = string.Empty;

            foreach (var item in ImageUrl)
                images += $"{item}\n";

            return
                $"Название: {Name}\n" +
                $"Стоимость: {Price}\n" +
                $"Изображения:\n{images}";
        }
    }
}
