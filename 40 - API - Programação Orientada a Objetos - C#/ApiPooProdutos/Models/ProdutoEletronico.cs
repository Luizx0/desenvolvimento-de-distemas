namespace ApiPooProdutos.Models;

public class ProdutoEletronico : ProdutoBase
{
    public decimal TaxaGarantia { get; set; }

    public override decimal CalcularPrecoFinal()
    {
        var precoComGarantia = PrecoBase * (1 + TaxaGarantia / 100);
        return Math.Round(precoComGarantia, 2);
    }

    public override string TipoProduto() => "Eletronico";
}
