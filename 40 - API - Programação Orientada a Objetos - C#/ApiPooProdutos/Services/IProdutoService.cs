using ApiPooProdutos.Models;

namespace ApiPooProdutos.Services;

public interface IProdutoService
{
    IEnumerable<ProdutoResponse> Listar();
    ProdutoResponse? BuscarPorId(int id);
    ProdutoResponse AdicionarComum(CriarProdutoComumRequest request);
    ProdutoResponse AdicionarEletronico(CriarProdutoEletronicoRequest request);
}
