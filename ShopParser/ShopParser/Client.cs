using ShopParser.Models;

namespace ShopParser
{
    public sealed class Client
    {
        private readonly DNS _dns;
        private readonly Eldorado _eldorado;
        private readonly Svyaznoy _svyaznoy;

        public Client()
        {
            _dns = new();
            _eldorado = new();
            _svyaznoy = new();
        }

        public ViewModel ParseDNS(string path)
        {
            return _dns.Parse(path);
        }

        public ViewModel ParseEldorado(string path)
        {
            return _eldorado.Parse(path);
        }

        public ViewModel ParseSvyaznoy(string path)
        {
            return _svyaznoy.Parse(path);
        }
    }
}