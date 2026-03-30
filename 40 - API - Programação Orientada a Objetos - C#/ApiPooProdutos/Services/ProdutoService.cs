using ApiPooProdutos.Models;

namespace ApiPooProdutos.Services;

public class ProdutoService : IProdutoService
{
    private static readonly List<ProdutoBase> Produtos =
    [
        new ProdutoComum { Id = 1, Nome = "Caderno", PrecoBase = 35.90m },
        new ProdutoEletronico { Id = 2, Nome = "Mouse Gamer", PrecoBase = 159.90m, TaxaGarantia = 10 }
    ];

    public IEnumerable<ProdutoResponse> Listar()
    {
        return Produtos.Select(MapearParaResponse);
    }

    public ProdutoResponse? BuscarPorId(int id)
    {
        var produto = Produtos.FirstOrDefault(p => p.Id == id);
        return produto is null ? null : MapearParaResponse(produto);
    }

    public ProdutoResponse AdicionarComum(CriarProdutoComumRequest request)
    {
        var produto = new ProdutoComum
        {
            Id = ProximoId(),
            Nome = request.Nome,
            PrecoBase = request.PrecoBase
        };

        Produtos.Add(produto);
        return MapearParaResponse(produto);
    }

    public ProdutoResponse AdicionarEletronico(CriarProdutoEletronicoRequest request)
    {
        var produto = new ProdutoEletronico
        {
            Id = ProximoId(),
            Nome = request.Nome,
            PrecoBase = request.PrecoBase,
            TaxaGarantia = request.TaxaGarantia
        };

        Produtos.Add(produto);
        return MapearParaResponse(produto);
    }

    private static int ProximoId()
    {
        return Produtos.Count == 0 ? 1 : Produtos.Max(p => p.Id) + 1;
    }

    private static ProdutoResponse MapearParaResponse(ProdutoBase produto)
    {
        return new ProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Tipo = produto.TipoProduto(),
            PrecoBase = produto.PrecoBase,
            PrecoFinal = produto.CalcularPrecoFinal()
        };
    }
}
