using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBoasPraticas.Models;
using ApiBoasPraticas.Data;
using ApiBoasPraticas.DTOs;
using ApiBoasPraticas.Models.Validacao;

namespace ApiBoasPraticas.Services
{
    /// <summary>
    /// Serviço que VIOLA os princípios KISS e DRY
    /// Criado para demonstração comparativa
    /// </summary>
    public class PessoaServiceViolacao
    {
        private readonly IPessoaRepository _repository;
        private readonly IValidacaoService _validacaoService;

        public PessoaServiceViolacao(IPessoaRepository repository, IValidacaoService validacaoService)
        {
            _repository = repository;
            _validacaoService = validacaoService;
        }

        /// <summary>
        /// Método que viola KISS - faz tudo de uma vez
        /// Viola DRY - duplica validações
        /// </summary>
        public async Task<PessoaDto> CriarPessoaComMultiplasValidacoes(
            CreatePessoaDto dto,
            bool validarCpfRemoto = false,
            bool enviarEmailConfirmacao = false,
            bool gerarRelatorio = false,
            bool notificarAdministrador = false)
        {
            // Validação duplicada aqui (VIOLA DRY)
            if (dto == null)
                throw new ValidationException("Dados inválidos");

            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new ValidationException("Nome obrigatório");

            if (dto.Nome.Trim().Length < 2)
                throw new ValidationException("Nome muito curto");

            if (string.IsNullOrWhiteSpace(dto.Cpf))
                throw new ValidationException("CPF obrigatório");

            // Validação de CPF duplicada (VIOLA DRY)
            var cpfLimpo = dto.Cpf.Replace(".", "").Replace("-", "");
            if (cpfLimpo.Length != 11)
                throw new ValidationException("CPF deve ter 11 dígitos");

            // Lógica complexa inline (VIOLA KISS)
            var soma = 0;
            var peso = 10;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpfLimpo[i] - '0') * peso;
                peso--;
            }
            var resto = soma % 11;
            var primeiroDigito = resto < 2 ? 0 : 11 - resto;

            if (primeiroDigito != cpfLimpo[9] - '0')
                throw new ValidationException("CPF inválido");

            // Mesmo cálculo para segundo dígito (DUPLICAÇÃO)
            soma = 0;
            peso = 11;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpfLimpo[i] - '0') * peso;
                peso--;
            }
            resto = soma % 11;
            var segundoDigito = resto < 2 ? 0 : 11 - resto;

            if (segundoDigito != cpfLimpo[10] - '0')
                throw new ValidationException("CPF inválido");

            // Verificar duplicidade (DUPLICAÇÃO)
            var pessoaExistente = await _repository.ObterPorCpfAsync(dto.Cpf);
            if (pessoaExistente != null)
                throw new ValidationException("CPF já cadastrado");

            // Validação de data duplicada (VIOLA DRY)
            if (dto.DataNascimento > DateTime.Now)
                throw new ValidationException("Data futura inválida");

            var idade = DateTime.Now.Year - dto.DataNascimento.Year;
            if (dto.DataNascimento.Date > DateTime.Now.AddYears(-idade))
                idade--;

            if (idade < 0)
                throw new ValidationException("Data inválida");

            // Criar pessoa
            var pessoa = new Pessoa
            {
                Nome = dto.Nome.Trim(),
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento
            };

            // Salvar
            var pessoaCriada = await _repository.AdicionarAsync(pessoa);

            // Múltiplas responsabilidades (VIOLA KISS)
            if (validarCpfRemoto)
            {
                // Simulação de validação remota (código complexo desnecessário)
                await Task.Delay(100); // Simula chamada externa
            }

            if (enviarEmailConfirmacao)
            {
                // Simulação de envio de email (lógica fora do escopo)
                // Código que deveria estar em outro serviço
            }

            if (gerarRelatorio)
            {
                // Simulação de geração de relatório (lógica fora do escopo)
                // Mais código complexo desnecessário
            }

            if (notificarAdministrador)
            {
                // Simulação de notificação (lógica fora do escopo)
                // Ainda mais código complexo
            }

            // Mapeamento duplicado (VIOLA DRY)
            return new PessoaDto
            {
                Id = pessoaCriada.Id,
                Nome = pessoaCriada.Nome,
                Cpf = pessoaCriada.Cpf,
                DataNascimento = pessoaCriada.DataNascimento,
                Idade = pessoaCriada.Idade,
                CriadoEm = pessoaCriada.CriadoEm
            };
        }
    }
}