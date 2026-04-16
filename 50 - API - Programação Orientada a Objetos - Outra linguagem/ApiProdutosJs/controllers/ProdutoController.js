import { Produto } from "../models/Produto.js";
import { Eletronico } from "../models/Eletronico.js";
import { Roupa } from "../models/Roupa.js";

/**
 * Controller para gerenciar produtos
 * Demonstra polimorfismo ao trabalhar com diferentes tipos de produtos
 */
export class ProdutoController {
  constructor() {
    // Array para armazenar os produtos (simula um banco de dados)
    this.produtos = this.inicializarProdutos();
    this.proximoId = 7; // Próximo ID disponível
  }

  /**
   * Inicializa os produtos de exemplo
   * Demonstra criação de diferentes tipos de produtos (polimorfismo)
   * @returns {Array} Array com produtos de exemplo
   */
  inicializarProdutos() {
    return [
      // Produtos do tipo Eletrônico
      new Eletronico(1, "Notebook Dell", 2500.00, 5, 110, "Dell", 24),
      new Eletronico(2, "Smartphone Samsung", 1200.00, 15, 110, "Samsung", 12),
      new Eletronico(3, "Cabo USB-C", 45.00, 50, 110, "Genérico", 6),
      
      // Produtos do tipo Roupa
      new Roupa(4, "Camiseta Básica", 49.90, 100, "M", "Branco", "Algodão", "Básica"),
      new Roupa(5, "Calça Jeans", 120.00, 80, "P", "Azul", "Denim", "Casual"),
      new Roupa(6, "Jaqueta de Couro", 350.00, 20, "G", "Preto", "Couro", "Premium")
    ];
  }

  /**
   * Obtém todos os produtos
   * @returns {Array} Array com todos os produtos
   */
  obterTodos() {
    // Utilizando map para transformar cada produto em seu objeto de informações
    // Demonstra polimorfismo: cada tipo de produto retorna suas próprias informações
    return this.produtos.map(produto => produto.obterInfo());
  }

  /**
   * Obtém um produto pelo ID
   * @param {number} id - ID do produto
   * @returns {Object|null} Objeto do produto ou null se não encontrado
   */
  obterPorId(id) {
    const produto = this.produtos.find(p => p.id === id);
    return produto ? produto.obterInfo() : null;
  }

  /**
   * Cria um novo produto
   * @param {Object} dados - Dados do produto
   * @returns {Object|null} Objeto do novo produto ou null em caso de erro
   */
  criar(dados) {
    try {
      let novoProduto;

      // Determina o tipo de produto a ser criado (polimorfismo)
      if (dados.tipo === "Eletronico") {
        novoProduto = new Eletronico(
          this.proximoId++,
          dados.nome,
          dados.preco,
          dados.estoque,
          dados.voltagem,
          dados.marca,
          dados.garantiaEmMeses
        );
      } else if (dados.tipo === "Roupa") {
        novoProduto = new Roupa(
          this.proximoId++,
          dados.nome,
          dados.preco,
          dados.estoque,
          dados.tamanho,
          dados.cor,
          dados.material,
          dados.colecao
        );
      } else {
        // Produto genérico como padrão
        novoProduto = new Produto(
          this.proximoId++,
          dados.nome,
          dados.preco,
          dados.estoque
        );
      }

      this.produtos.push(novoProduto);
      return novoProduto.obterInfo();
    } catch (erro) {
      console.error("Erro ao criar produto:", erro);
      return null;
    }
  }

  /**
   * Atualiza um produto existente
   * @param {number} id - ID do produto
   * @param {Object} dados - Novos dados do produto
   * @returns {Object|null} Objeto atualizado ou null se não encontrado
   */
  atualizar(id, dados) {
    const produto = this.produtos.find(p => p.id === id);
    
    if (!produto) {
      return null;
    }

    // Atualiza propriedades comuns
    if (dados.nome) produto.nome = dados.nome;
    if (dados.preco) produto.preco = dados.preco;
    if (dados.estoque !== undefined) produto.estoque = dados.estoque;

    // Atualiza propriedades específicas dependendo do tipo (polimorfismo)
    if (produto instanceof Eletronico) {
      if (dados.voltagem) produto.voltagem = dados.voltagem;
      if (dados.marca) produto.marca = dados.marca;
      if (dados.garantiaEmMeses) produto.garantiaEmMeses = dados.garantiaEmMeses;
    } else if (produto instanceof Roupa) {
      if (dados.tamanho) produto.tamanho = dados.tamanho;
      if (dados.cor) produto.cor = dados.cor;
      if (dados.material) produto.material = dados.material;
      if (dados.colecao) produto.colecao = dados.colecao;
    }

    return produto.obterInfo();
  }

  /**
   * Deleta um produto
   * @param {number} id - ID do produto
   * @returns {boolean} True se deletado com sucesso, false caso contrário
   */
  deletar(id) {
    const index = this.produtos.findIndex(p => p.id === id);
    
    if (index === -1) {
      return false;
    }

    this.produtos.splice(index, 1);
    return true;
  }

  /**
   * Obtém descrição de um produto
   * @param {number} id - ID do produto
   * @returns {string|null} Descrição do produto
   */
  obterDescricao(id) {
    const produto = this.produtos.find(p => p.id === id);
    return produto ? produto.obterDescricao() : null;
  }

  /**
   * Filtra produtos por tipo
   * @param {string} tipo - Tipo de produto (Eletronico, Roupa)
   * @returns {Array} Array com produtos do tipo especificado
   */
  filtrarPorTipo(tipo) {
    let produtos = [];

    if (tipo === "Eletronico") {
      produtos = this.produtos.filter(p => p instanceof Eletronico);
    } else if (tipo === "Roupa") {
      produtos = this.produtos.filter(p => p instanceof Roupa);
    } else {
      produtos = this.produtos;
    }

    return produtos.map(p => p.obterInfo());
  }

  /**
   * Obtém produtos em estoque baixo
   * @param {number} limite - Limite de estoque
   * @returns {Array} Array com produtos com estoque abaixo do limite
   */
  obterEstoqueBaixo(limite = 10) {
    return this.produtos
      .filter(p => p.estoque <= limite)
      .map(p => ({
        ...p.obterInfo(),
        statusEstoque: "BAIXO"
      }));
  }

  /**
   * Calcula valor total do inventário
   * @returns {number} Valor total do inventário
   */
  calcularValorInventario() {
    return this.produtos.reduce((total, produto) => {
      return total + produto.calcularValorTotal();
    }, 0);
  }

  /**
   * Obtém informações de um eletrônico (exemplo de método polimórfico)
   * @param {number} id - ID do eletrônico
   * @returns {Object|null} Informações específicas do eletrônico
   */
  obterInfoEletronico(id) {
    const produto = this.produtos.find(p => p.id === id);
    
    if (!produto || !(produto instanceof Eletronico)) {
      return null;
    }

    return {
      ...produto.obterInfo(),
      seguro: produto.calcularSeguro(),
      emGarantia: produto.estaEmGarantia(30) // Exemplo: 30 dias de uso
    };
  }

  /**
   * Obtém informações de uma roupa (exemplo de método polimórfico)
   * @param {number} id - ID da roupa
   * @returns {Object|null} Informações específicas da roupa
   */
  obterInfoRoupa(id) {
    const produto = this.produtos.find(p => p.id === id);
    
    if (!produto || !(produto instanceof Roupa)) {
      return null;
    }

    return {
      ...produto.obterInfo(),
      desconto: produto.calcularDescontoColecao(),
      cuidados: produto.obterCuidados(),
      disponibilidade: produto.verificarDisponibilidade()
    };
  }
}

// Criando instância única do controller (Singleton pattern)
export const produtoController = new ProdutoController();
