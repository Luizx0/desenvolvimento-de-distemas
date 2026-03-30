namespace ApiPooProdutos.Models;

public class ProdutoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal PrecoBase { get; set; }
    public decimal PrecoFinal { get; set; }
}
