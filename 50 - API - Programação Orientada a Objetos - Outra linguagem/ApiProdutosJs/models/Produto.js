/**
 * Classe base para representar um Produto
 * Esta classe implementa a superclasse e demonstra encapsulamento
 */
export class Produto {
  constructor(id, nome, preco, estoque) {
    this.id = id;
    this.nome = nome;
    this.preco = preco;
    this.estoque = estoque;
  }

  /**
   * Método para obter informações básicas do produto
   * @returns {Object} Objeto com informações do produto
   */
  obterInfo() {
    return {
      id: this.id,
      nome: this.nome,
      preco: this.preco,
      estoque: this.estoque,
      tipo: "Produto Genérico"
    };
  }

  /**
   * Método para calcular o valor total em estoque
   * @returns {number} Valor total em estoque
   */
  calcularValorTotal() {
    return this.preco * this.estoque;
  }

  /**
   * Método para atualizar o preço
   * @param {number} novoPreco - Novo preço do produto
   */
  atualizarPreco(novoPreco) {
    if (novoPreco > 0) {
      this.preco = novoPreco;
      return true;
    }
    return false;
  }

  /**
   * Método para atualizar estoque
   * @param {number} quantidade - Quantidade a adicionar (ou subtrair se negativo)
   */
  atualizarEstoque(quantidade) {
    this.estoque += quantidade;
    if (this.estoque < 0) {
      this.estoque = 0;
    }
  }

  /**
   * Método para obter descrição do produto
   * Este método será sobrescrito pelas subclasses (polimorfismo)
   * @returns {string} Descrição do produto
   */
  obterDescricao() {
    return `${this.nome} - R$ ${this.preco.toFixed(2)}`;
  }
}
