import { Produto } from "./Produto.js";

/**
 * Classe Roupa que herda de Produto
 * Demonstra herança ao estender a classe Produto
 * Demonstra polimorfismo ao sobrescrever métodos da classe pai
 */
export class Roupa extends Produto {
  constructor(id, nome, preco, estoque, tamanho, cor, material, colecao) {
    // Chamando o construtor da superclasse
    super(id, nome, preco, estoque);
    
    // Atributos específicos de roupas
    this.tamanho = tamanho;
    this.cor = cor;
    this.material = material;
    this.colecao = colecao;
  }

  /**
   * Sobrescrita do método obterInfo (polimorfismo)
   * Retorna informações específicas de roupas
   * @returns {Object} Objeto com informações da roupa
   */
  obterInfo() {
    return {
      ...super.obterInfo(),
      tamanho: this.tamanho,
      cor: this.cor,
      material: this.material,
      colecao: this.colecao,
      tipo: "Roupa"
    };
  }

  /**
   * Sobrescrita do método obterDescricao (polimorfismo)
   * Retorna descrição específica de roupas
   * @returns {string} Descrição da roupa
   */
  obterDescricao() {
    return `${this.nome} - Tamanho ${this.tamanho}, Cor ${this.cor} (${this.material}) - R$ ${this.preco.toFixed(2)} - Coleção: ${this.colecao}`;
  }

  /**
   * Método para aplicar desconto de coleção
   * Método específico da classe Roupa
   * @param {number} percentualDesconto - Percentual de desconto
   * @returns {number} Valor do desconto
   */
  calcularDescontoColecao(percentualDesconto = 10) {
    return (this.preco * percentualDesconto) / 100;
  }

  /**
   * Método para obter recomendações de cuidado
   * @returns {Array} Array com recomendações de cuidado
   */
  obterCuidados() {
    const cuidados = {
      "algodão": ["Lavar em água morna", "Não usar alvejante", "Secar ao ar livre"],
      "poliéster": ["Lavar em água fria", "Baixa temperatura na secadora", "Usar vapor suave"],
      "lã": ["Lavar à mão", "Água fria", "Secar deitado no plano"],
      "seda": ["Lavar delicadamente", "Água morna", "Não torcer"]
    };
    
    return cuidados[this.material.toLowerCase()] || ["Seguir instruções da etiqueta"];
  }

  /**
   * Método para verificar disponibilidade de tamanho e cor
   * @returns {string} Status de disponibilidade
   */
  verificarDisponibilidade() {
    if (this.estoque > 10) return "Em estoque abundante";
    if (this.estoque > 0) return "Disponível";
    return "Fora de estoque";
  }
}
