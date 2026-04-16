using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBoasPraticas.Models;
using ApiBoasPraticas.Data;
using ApiBoasPraticas.DTOs;
using ApiBoasPraticas.Models.Validacao;

namespace ApiBoasPraticas.Services
{
    /// <summary>
    /// Serviço de Pessoa - Demonstra boas práticas KISS
    /// Métodos simples, uma responsabilidade por método
    /// </summary>
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDto>> ObterTodosAsync();
        Task<PessoaDto?> ObterPorIdAsync(int id);
        Task<PessoaDto> CriarAsync(CreatePessoaDto dto);
        Task<PessoaDto> AtualizarAsync(int id, UpdatePessoaDto dto);
        Task<bool> RemoverAsync(int id);
    }

    /// <summary>
    /// Implementação do serviço de pessoa
    /// Lógica de negócio simples e direta
    /// </summary>
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;
        private readonly IValidacaoService _validacaoService;

        public PessoaService(IPessoaRepository repository, IValidacaoService validacaoService)
        {
            _repository = repository;
            _validacaoService = validacaoService;
        }

        /// <summary>
        /// Obtém todas as pessoas - método simples
        /// </summary>
        public async Task<IEnumerable<PessoaDto>> ObterTodosAsync()
        {
            var pessoas = await _repository.ObterTodosAsync();
            return pessoas.Select(MapToDto);
        }

        /// <summary>
        /// Obtém pessoa por ID - método simples
        /// </summary>
        public async Task<PessoaDto?> ObterPorIdAsync(int id)
        {
            var pessoa = await _repository.ObterPorIdAsync(id);
            return pessoa != null ? MapToDto(pessoa) : null;
        }

        /// <summary>
        /// Cria nova pessoa - método simples e focado
        /// </summary>
        public async Task<PessoaDto> CriarAsync(CreatePessoaDto dto)
        {
            // Validação simples
            var validation = _validacaoService.ValidarPessoa(dto.Nome, dto.Cpf, dto.DataNascimento);
            if (!validation.IsValid)
                throw new ValidationException(validation.ErrorMessage);

            // Verificar duplicidade de CPF
            if (await _repository.CpfExisteAsync(dto.Cpf))
                throw new ValidationException("CPF já cadastrado");

            // Criar entidade
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento
            };

            // Salvar
            var pessoaCriada = await _repository.AdicionarAsync(pessoa);

            return MapToDto(pessoaCriada);
        }

        /// <summary>
        /// Atualiza pessoa - método simples
        /// </summary>
        public async Task<PessoaDto> AtualizarAsync(int id, UpdatePessoaDto dto)
        {
            var pessoaExistente = await _repository.ObterPorIdAsync(id);
            if (pessoaExistente == null)
                throw new KeyNotFoundException("Pessoa não encontrada");

            // Aplicar updates apenas nos campos fornecidos
            if (!string.IsNullOrEmpty(dto.Nome))
                pessoaExistente.Nome = dto.Nome;

            if (!string.IsNullOrEmpty(dto.Cpf))
            {
                // Validar CPF se fornecido
                var cpfValidation = _validacaoService.ValidarCpf(dto.Cpf);
                if (!cpfValidation.IsValid)
                    throw new ValidationException(cpfValidation.ErrorMessage);

                // Verificar duplicidade
                if (await _repository.CpfExisteAsync(dto.Cpf, id))
                    throw new ValidationException("CPF já cadastrado");

                pessoaExistente.Cpf = dto.Cpf;
            }

            if (dto.DataNascimento.HasValue)
            {
                var dataValidation = _validacaoService.ValidarDataNascimento(dto.DataNascimento.Value);
                if (!dataValidation.IsValid)
                    throw new ValidationException(dataValidation.ErrorMessage);

                pessoaExistente.DataNascimento = dto.DataNascimento.Value;
            }

            var pessoaAtualizada = await _repository.AtualizarAsync(pessoaExistente);
            return MapToDto(pessoaAtualizada);
        }

        /// <summary>
        /// Remove pessoa - método simples
        /// </summary>
        public async Task<bool> RemoverAsync(int id)
        {
            return await _repository.RemoverAsync(id);
        }

        /// <summary>
        /// Método auxiliar para mapeamento - DRY
        /// </summary>
        private PessoaDto MapToDto(Pessoa pessoa)
        {
            return new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento,
                Idade = pessoa.Idade,
                CriadoEm = pessoa.CriadoEm
            };
        }
    }

    /// <summary>
    /// Exceção de validação personalizada
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}