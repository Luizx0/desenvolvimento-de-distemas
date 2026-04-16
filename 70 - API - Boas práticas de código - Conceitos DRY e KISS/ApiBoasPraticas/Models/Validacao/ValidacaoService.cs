using ApiBoasPraticas.Models.Validacao;

namespace ApiBoasPraticas.Models.Validacao
{
    /// <summary>
    /// Serviço de validação centralizado - Demonstra DRY
    /// Todas as validações em um lugar, evitando duplicação
    /// </summary>
    public interface IValidacaoService
    {
        ValidationResult ValidarPessoa(string nome, string cpf, DateTime dataNascimento);
        ValidationResult ValidarCpf(string cpf);
        ValidationResult ValidarNome(string nome);
        ValidationResult ValidarDataNascimento(DateTime dataNascimento);
    }

    /// <summary>
    /// Resultado de validação
    /// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResult(bool isValid, string errorMessage = "")
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success() => new ValidationResult(true);
        public static ValidationResult Failure(string message) => new ValidationResult(false, message);
    }

    /// <summary>
    /// Implementação do serviço de validação
    /// Centraliza todas as regras de negócio em um lugar
    /// </summary>
    public class ValidacaoService : IValidacaoService
    {
        private readonly ICpfValidator _cpfValidator;

        public ValidacaoService(ICpfValidator cpfValidator)
        {
            _cpfValidator = cpfValidator;
        }

        /// <summary>
        /// Validação completa de pessoa - método único e reutilizável
        /// </summary>
        public ValidationResult ValidarPessoa(string nome, string cpf, DateTime dataNascimento)
        {
            var nomeValidation = ValidarNome(nome);
            if (!nomeValidation.IsValid)
                return nomeValidation;

            var cpfValidation = ValidarCpf(cpf);
            if (!cpfValidation.IsValid)
                return cpfValidation;

            var dataValidation = ValidarDataNascimento(dataNascimento);
            if (!dataValidation.IsValid)
                return dataValidation;

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validação de CPF usando serviço centralizado
        /// </summary>
        public ValidationResult ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return ValidationResult.Failure("CPF é obrigatório");

            if (!_cpfValidator.IsValid(cpf))
                return ValidationResult.Failure("CPF inválido");

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validação de nome
        /// </summary>
        public ValidationResult ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return ValidationResult.Failure("Nome é obrigatório");

            if (nome.Trim().Length < 2)
                return ValidationResult.Failure("Nome deve ter pelo menos 2 caracteres");

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validação de data de nascimento
        /// </summary>
        public ValidationResult ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento > DateTime.Now)
                return ValidationResult.Failure("Data de nascimento não pode ser futura");

            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Now.AddYears(-idade))
                idade--;

            if (idade < 0)
                return ValidationResult.Failure("Data de nascimento inválida");

            return ValidationResult.Success();
        }
    }
}