using ShopParser.Models;
using System.Text.Json;

namespace ShopParser
{
    internal class Svyaznoy
    {
        public ViewModel Parse(string path)
        {
            string data;
            using var reader = new StreamReader(path);

            data = reader.ReadToEnd();

            return JsonSerializer.Deserialize<SvyaznoyModel>(data).ToViewModel();
        }
    }
}
