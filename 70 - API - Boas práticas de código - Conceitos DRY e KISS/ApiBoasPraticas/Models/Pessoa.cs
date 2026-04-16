using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBoasPraticas.Models
{
    /// <summary>
    /// Entidade Pessoa - demonstra boas práticas KISS
    /// Validações simples e diretas no modelo
    /// </summary>
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Nome deve ter pelo menos 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF deve estar no formato XXX.XXX.XXX-XX")]
        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        /// <summary>
        /// Propriedade calculada - idade baseada na data de nascimento
        /// </summary>
        public int Idade => CalcularIdade();

        /// <summary>
        /// Método simples para calcular idade
        /// </summary>
        private int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}