namespace ApiPooProdutos.Models;

public abstract class ProdutoBase
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoBase { get; set; }

    public abstract decimal CalcularPrecoFinal();

    public virtual string TipoProduto() => "Generico";
}
