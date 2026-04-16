using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiEncapsulamento.Models
{
    /// <summary>
    /// Classe Usuario que demonstra o conceito de encapsulamento
    /// Campos privados são protegidos e acessados apenas através de propriedades públicas validadas
    /// </summary>
    public class Usuario
    {
        // Campos privados - encapsulamento dos dados
        private int _id;
        private string _nome;
        private string _email;
        private DateTime _dataNascimento;
        private bool _ativo;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Usuario() { }

        /// <summary>
        /// Construtor com parâmetros para criação de usuário
        /// </summary>
        public Usuario(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome; // Usa setter com validação
            Email = email; // Usa setter com validação
            DataNascimento = dataNascimento; // Usa setter com validação
            _ativo = true; // Usuários novos são ativos por padrão
        }

        /// <summary>
        /// Propriedade Id - somente leitura (definida internamente)
        /// </summary>
        public int Id
        {
            get { return _id; }
            internal set { _id = value; } // Apenas classes internas podem definir
        }

        /// <summary>
        /// Propriedade Nome com validação
        /// Demonstra encapsulamento: validação antes de armazenar
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio ou conter apenas espaços em branco");

                if (value.Trim().Length < 2)
                    throw new ArgumentException("Nome deve ter pelo menos 2 caracteres");

                _nome = value.Trim();
            }
        }

        /// <summary>
        /// Propriedade Email com validação de formato
        /// Demonstra encapsulamento: validação de formato e normalização
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email não pode ser vazio");

                // Regex simples para validação de email
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!emailRegex.IsMatch(value))
                    throw new ArgumentException("Email deve ter formato válido (exemplo@dominio.com)");

                _email = value.ToLower().Trim(); // Normaliza para minúsculo
            }
        }

        /// <summary>
        /// Propriedade DataNascimento com validação
        /// Demonstra encapsulamento: validação de lógica de negócio
        /// </summary>
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Data de nascimento não pode ser futura");

                var idade = CalcularIdade(value);
                if (idade < 13)
                    throw new ArgumentException("Usuário deve ter pelo menos 13 anos");

                _dataNascimento = value;
            }
        }

        /// <summary>
        /// Propriedade Idade - calculada dinamicamente, somente leitura
        /// Demonstra encapsulamento: propriedade derivada, não armazenada
        /// </summary>
        public int Idade
        {
            get { return CalcularIdade(_dataNascimento); }
        }

        /// <summary>
        /// Propriedade Ativo com controle de acesso
        /// Demonstra encapsulamento: controle de estado através de métodos específicos
        /// </summary>
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; } // Setter privado, alteração via método público
        }

        /// <summary>
        /// Método público para alterar o status do usuário
        /// Demonstra encapsulamento: controle de acesso através de interface pública
        /// </summary>
        public void AlterarStatus(bool novoStatus)
        {
            // Lógica de negócio: pode adicionar validações ou logs aqui
            if (novoStatus && !_ativo)
            {
                // Reativando usuário - poderia enviar email de boas-vindas
                _ativo = true;
            }
            else if (!novoStatus && _ativo)
            {
                // Desativando usuário - poderia fazer limpeza ou backup
                _ativo = false;
            }
        }

        /// <summary>
        /// Método público para atualizar dados do usuário
        /// Demonstra encapsulamento: interface consistente para atualizações
        /// </summary>
        public void AtualizarDados(string nome, string email, DateTime dataNascimento)
        {
            // Usa os setters com validação para cada propriedade
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        /// <summary>
        /// Método público para obter informações formatadas
        /// Demonstra encapsulamento: interface de leitura formatada
        /// </summary>
        public string ObterInformacoesFormatadas()
        {
            return $"ID: {Id}\n" +
                   $"Nome: {Nome}\n" +
                   $"Email: {Email}\n" +
                   $"Data de Nascimento: {DataNascimento:dd/MM/yyyy}\n" +
                   $"Idade: {Idade} anos\n" +
                   $"Status: {(Ativo ? "Ativo" : "Inativo")}";
        }

        /// <summary>
        /// Método auxiliar privado para calcular idade
        /// </summary>
        private int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Now;
            var idade = hoje.Year - dataNascimento.Year;

            // Ajusta se ainda não fez aniversário este ano
            if (dataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}