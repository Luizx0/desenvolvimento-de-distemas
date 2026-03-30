namespace ApiPooProdutos.Models;

public record CriarProdutoComumRequest(string Nome, decimal PrecoBase);

public record CriarProdutoEletronicoRequest(string Nome, decimal PrecoBase, decimal TaxaGarantia);
