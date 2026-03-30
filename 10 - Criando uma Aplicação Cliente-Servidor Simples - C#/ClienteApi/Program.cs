using System.Net.Http;
using System.Text.Json;

HttpClient client = new HttpClient();

client.BaseAddress = new Uri("http://localhost:5295/");

var response = await client.GetAsync("api/produtos");

if (response.IsSuccessStatusCode)
{
    var json = await response.Content.ReadAsStringAsync();

    var produtos = JsonSerializer.Deserialize<List<Produto>>(json);

    foreach (var p in produtos)
    {
        Console.WriteLine($"{p.Id} - {p.Nome} - R$ {p.Preco}");
    }
}

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
}