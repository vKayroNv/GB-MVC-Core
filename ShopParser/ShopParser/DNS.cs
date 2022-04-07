using ShopParser.Models;
using System.Text.Json;

namespace ShopParser
{
    internal class DNS
    {
        public ViewModel Parse(string path)
        {
            string data;
            using var reader = new StreamReader(path);

            data = reader.ReadToEnd();

            return JsonSerializer.Deserialize<DNSModel>(data).ToViewModel();
        }
    }
}
