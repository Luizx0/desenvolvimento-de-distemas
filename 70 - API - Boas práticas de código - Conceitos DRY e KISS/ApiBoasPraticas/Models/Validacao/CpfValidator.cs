using System.Text.RegularExpressions;

namespace ApiBoasPraticas.Models.Validacao
{
    /// <summary>
    /// Validador de CPF - Demonstra DRY (Don't Repeat Yourself)
    /// Serviço centralizado e reutilizável para validação de CPF
    /// </summary>
    public interface ICpfValidator
    {
        bool IsValid(string cpf);
        string Format(string cpf);
    }

    /// <summary>
    /// Implementação do validador de CPF
    /// Lógica centralizada, evitando duplicação de código
    /// </summary>
    public class CpfValidator : ICpfValidator
    {
        /// <summary>
        /// Valida se o CPF é válido
        /// Algoritmo oficial de validação dos dígitos verificadores
        /// </summary>
        public bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove formatação
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se não é sequencial (111.111.111-11, etc.)
            if (Regex.IsMatch(cpf, @"^(\d)\1{10}$"))
                return false;

            // Calcula primeiro dígito verificador
            var primeiroDigito = CalcularDigitoVerificador(cpf, 10);
            if (primeiroDigito != cpf[9] - '0')
                return false;

            // Calcula segundo dígito verificador
            var segundoDigito = CalcularDigitoVerificador(cpf, 11);
            if (segundoDigito != cpf[10] - '0')
                return false;

            return true;
        }

        /// <summary>
        /// Formata CPF no padrão XXX.XXX.XXX-XX
        /// </summary>
        public string Format(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return cpf;

            // Remove formatação existente
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Aplica formatação se tiver 11 dígitos
            if (cpf.Length == 11)
            {
                return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
            }

            return cpf;
        }

        /// <summary>
        /// Calcula dígito verificador do CPF
        /// Algoritmo oficial da Receita Federal
        /// </summary>
        private int CalcularDigitoVerificador(string cpf, int pesoInicial)
        {
            var soma = 0;
            var peso = pesoInicial;

            for (int i = 0; i < peso - 1; i++)
            {
                soma += (cpf[i] - '0') * peso;
                peso--;
            }

            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}