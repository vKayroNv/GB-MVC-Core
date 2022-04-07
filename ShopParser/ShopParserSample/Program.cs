ShopParser.Client client = new();

Console.WriteLine(client.ParseDNS("json\\dns.json"));
Console.WriteLine(client.ParseEldorado("json\\eldorado.json"));
Console.WriteLine(client.ParseSvyaznoy("json\\svyaznoy.json"));