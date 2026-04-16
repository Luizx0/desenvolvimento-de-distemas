import node_fetch from 'node-fetch';

/**
 * Cliente para consumir a API de Produtos
 * Demonstra como fazer requisições HTTP para a API
 */

const BASE_URL = "http://localhost:3000/api";

/**
 * Classe Cliente para consumir API de Produtos
 */
class ClienteProdutosApi {
  constructor(baseUrl = BASE_URL) {
    this.baseUrl = baseUrl;
  }

  /**
   * Método auxiliar para fazer requisições
   */
  async fazRequisicao(endpoint, opcoes = {}) {
    try {
      const url = `${this.baseUrl}${endpoint}`;
      const resposta = await fetch(url, {
        headers: {
          "Content-Type": "application/json",
          ...opcoes.headers
        },
        ...opcoes
      });

      if (!resposta.ok) {
        throw new Error(`Erro HTTP: ${resposta.status}`);
      }

      return await resposta.json();
    } catch (erro) {
      console.error(`Erro na requisição para ${endpoint}:`, erro);
      throw erro;
    }
  }

  /**
   * Obtém todos os produtos
   */
  async obterTodosProdutos() {
    return this.fazRequisicao("/produtos");
  }

  /**
   * Obtém um produto por ID
   */
  async obterProdutoPorId(id) {
    return this.fazRequisicao(`/produtos/${id}`);
  }

  /**
   * Obtém produtos por tipo
   */
  async obterProdutosPorTipo(tipo) {
    return this.fazRequisicao(`/produtos/tipo/${tipo}`);
  }

  /**
   * Obtém informações detalhadas de um eletrônico
   */
  async obterInfoEletronico(id) {
    return this.fazRequisicao(`/produtos/info/eletronico/${id}`);
  }

  /**
   * Obtém informações detalhadas de uma roupa
   */
  async obterInfoRoupa(id) {
    return this.fazRequisicao(`/produtos/info/roupa/${id}`);
  }

  /**
   * Cria um novo eletrônico
   */
  async criarEletronico(dados) {
    return this.fazRequisicao("/produtos", {
      method: "POST",
      body: JSON.stringify({
        tipo: "Eletronico",
        ...dados
      })
    });
  }

  /**
   * Cria uma nova roupa
   */
  async criarRoupa(dados) {
    return this.fazRequisicao("/produtos", {
      method: "POST",
      body: JSON.stringify({
        tipo: "Roupa",
        ...dados
      })
    });
  }

  /**
   * Atualiza um produto
   */
  async atualizarProduto(id, dados) {
    return this.fazRequisicao(`/produtos/${id}`, {
      method: "PUT",
      body: JSON.stringify(dados)
    });
  }

  /**
   * Deleta um produto
   */
  async deletarProduto(id) {
    return this.fazRequisicao(`/produtos/${id}`, {
      method: "DELETE"
    });
  }

  /**
   * Obtém produtos com estoque baixo
   */
  async obterEstoqueBaixo(limite = 10) {
    return this.fazRequisicao(`/produtos/estoque/baixo/${limite}`);
  }
}

// ========== EXEMPLOS DE USO ==========

/**
 * Função para exibir resultados formatados
 */
function exibirResultado(titulo, dados) {
  console.log("\n" + "=".repeat(60));
  console.log(titulo);
  console.log("=".repeat(60));
  console.log(JSON.stringify(dados, null, 2));
}

/**
 * Função principal para testar o cliente
 */
async function testarCliente() {
  console.log("🚀 Iniciando teste do cliente da API de Produtos\n");

  const cliente = new ClienteProdutosApi();

  try {
    // 1. Obter todos os produtos
    console.log("1️⃣  Obtendo todos os produtos...");
    const todosProdutos = await cliente.obterTodosProdutos();
    exibirResultado("✅ Todos os Produtos", todosProdutos);

    // 2. Obter um produto específico
    console.log("\n2️⃣  Obtendo produto com ID 1...");
    const produto1 = await cliente.obterProdutoPorId(1);
    exibirResultado("✅ Produto com ID 1", produto1);

    // 3. Obter apenas eletrônicos
    console.log("\n3️⃣  Filtrando eletrônicos...");
    const eletronicos = await cliente.obterProdutosPorTipo("Eletronico");
    exibirResultado("✅ Eletrônicos", eletronicos);

    // 4. Obter apenas roupas
    console.log("\n4️⃣  Filtrando roupas...");
    const roupas = await cliente.obterProdutosPorTipo("Roupa");
    exibirResultado("✅ Roupas", roupas);

    // 5. Obter informações específicas de um eletrônico
    console.log("\n5️⃣  Obtendo informações de eletrônico (ID 1)...");
    const infoEletronico = await cliente.obterInfoEletronico(1);
    exibirResultado("✅ Informações Detalhadas de Eletrônico", infoEletronico);

    // 6. Obter informações específicas de uma roupa
    console.log("\n6️⃣  Obtendo informações de roupa (ID 4)...");
    const infoRoupa = await cliente.obterInfoRoupa(4);
    exibirResultado("✅ Informações Detalhadas de Roupa", infoRoupa);

    // 7. Criar um novo eletrônico
    console.log("\n7️⃣  Criando novo eletrônico...");
    const novoEletronico = await cliente.criarEletronico({
      nome: "Monitor Gamer 144Hz",
      preco: 1200.00,
      estoque: 5,
      voltagem: 110,
      marca: "ASUS",
      garantiaEmMeses: 24
    });
    exibirResultado("✅ Novo Eletrônico Criado", novoEletronico);

    // 8. Criar uma nova roupa
    console.log("\n8️⃣  Criando nova roupa...");
    const novaRoupa = await cliente.criarRoupa({
      nome: "Tênis Esportivo",
      preco: 250.00,
      estoque: 30,
      tamanho: "41",
      cor: "Azul",
      material: "Poliéster",
      colecao: "Esportiva"
    });
    exibirResultado("✅ Nova Roupa Criada", novaRoupa);

    // 9. Atualizar um produto
    console.log("\n9️⃣  Atualizando produto (ID 1)...");
    const produtoAtualizado = await cliente.atualizarProduto(1, {
      preco: 2800.00,
      estoque: 8
    });
    exibirResultado("✅ Produto Atualizado", produtoAtualizado);

    // 10. Obter produtos com estoque baixo
    console.log("\n🔟 Obtendo produtos com estoque baixo (limite: 15)...");
    const estoqueBaixo = await cliente.obterEstoqueBaixo(15);
    exibirResultado("✅ Produtos com Estoque Baixo", estoqueBaixo);

    console.log("\n" + "=".repeat(60));
    console.log("✨ Testes concluídos com sucesso!");
    console.log("=".repeat(60));

  } catch (erro) {
    console.error("❌ Erro durante os testes:", erro);
  }
}

// Executar testes se este for o arquivo principal
if (import.meta.url === `file://${process.argv[1]}`) {
  testarCliente();
}

export { ClienteProdutosApi };
