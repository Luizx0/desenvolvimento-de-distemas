using System.ComponentModel.DataAnnotations;

namespace ApiBoasPraticas.DTOs
{
    /// <summary>
    /// DTO para retorno de dados da Pessoa
    /// Demonstra boas práticas de exposição de dados
    /// </summary>
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public DateTime CriadoEm { get; set; }
    }

    /// <summary>
    /// DTO para criação de Pessoa
    /// Validações simples e diretas
    /// </summary>
    public class CreatePessoaDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Nome deve ter pelo menos 2 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF deve estar no formato XXX.XXX.XXX-XX")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
    }

    /// <summary>
    /// DTO para atualização de Pessoa
    /// Campos opcionais para updates parciais
    /// </summary>
    public class UpdatePessoaDto
    {
        [MinLength(2, ErrorMessage = "Nome deve ter pelo menos 2 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF deve estar no formato XXX.XXX.XXX-XX")]
        public string? Cpf { get; set; }

        public DateTime? DataNascimento { get; set; }
    }
}