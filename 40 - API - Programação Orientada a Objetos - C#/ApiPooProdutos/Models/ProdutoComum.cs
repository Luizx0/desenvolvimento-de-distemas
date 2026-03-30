namespace ApiPooProdutos.Models;

public class ProdutoComum : ProdutoBase
{
    public override decimal CalcularPrecoFinal()
    {
        return Math.Round(PrecoBase, 2);
    }

    public override string TipoProduto() => "Comum";
}
