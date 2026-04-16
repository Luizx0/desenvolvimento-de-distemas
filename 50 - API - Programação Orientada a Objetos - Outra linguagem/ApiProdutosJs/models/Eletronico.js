import { Produto } from "./Produto.js";

/**
 * Classe Eletronico que herda de Produto
 * Demonstra herança ao estender a classe Produto
 * Demonstra polimorfismo ao sobrescrever métodos da classe pai
 */
export class Eletronico extends Produto {
  constructor(id, nome, preco, estoque, voltagem, marca, garantiaEmMeses) {
    // Chamando o construtor da superclasse
    super(id, nome, preco, estoque);
    
    // Atributos específicos de eletrônicos
    this.voltagem = voltagem;
    this.marca = marca;
    this.garantiaEmMeses = garantiaEmMeses;
  }

  /**
   * Sobrescrita do método obterInfo (polimorfismo)
   * Retorna informações específicas de eletrônicos
   * @returns {Object} Objeto com informações do eletrônico
   */
  obterInfo() {
    return {
      ...super.obterInfo(),
      voltagem: this.voltagem,
      marca: this.marca,
      garantiaEmMeses: this.garantiaEmMeses,
      tipo: "Eletrônico"
    };
  }

  /**
   * Sobrescrita do método obterDescricao (polimorfismo)
   * Retorna descrição específica de eletrônicos
   * @returns {string} Descrição do eletrônico
   */
  obterDescricao() {
    return `${this.nome} (${this.marca}) - ${this.voltagem}V - R$ ${this.preco.toFixed(2)} - Garantia: ${this.garantiaEmMeses} meses`;
  }

  /**
   * Método adicionar taxa de seguro
   * Método específico da classe Eletronico
   * @param {number} percentual - Percentual de taxa de seguro
   * @returns {number} Valor do seguro
   */
  calcularSeguro(percentual = 5) {
    return (this.preco * percentual) / 100;
  }

  /**
   * Método para verificar se está dentro da garantia
   * @param {number} diasUso - Dias de uso do eletrônico
   * @returns {boolean} True se está dentro da garantia
   */
  estaEmGarantia(diasUso) {
    const diasGarantia = this.garantiaEmMeses * 30;
    return diasUso <= diasGarantia;
  }
}
