using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiBoasPraticas.Models;

namespace ApiBoasPraticas.Data
{
    /// <summary>
    /// Repository Pattern - Demonstra boas práticas DRY
    /// Interface única para acesso a dados, reutilizável
    /// </summary>
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> ObterTodosAsync();
        Task<Pessoa?> ObterPorIdAsync(int id);
        Task<Pessoa?> ObterPorCpfAsync(string cpf);
        Task<Pessoa> AdicionarAsync(Pessoa pessoa);
        Task<Pessoa> AtualizarAsync(Pessoa pessoa);
        Task<bool> RemoverAsync(int id);
        Task<bool> ExisteAsync(int id);
        Task<bool> CpfExisteAsync(string cpf, int? excludeId = null);
    }

    /// <summary>
    /// Implementação do Repository para Pessoa
    /// Centraliza todo acesso a dados em um lugar
    /// </summary>
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> ObterTodosAsync()
        {
            return await _context.Pessoas
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<Pessoa?> ObterPorIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<Pessoa?> ObterPorCpfAsync(string cpf)
        {
            return await _context.Pessoas
                .FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<Pessoa> AdicionarAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> AtualizarAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            if (pessoa == null)
                return false;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _context.Pessoas.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> CpfExisteAsync(string cpf, int? excludeId = null)
        {
            var query = _context.Pessoas.Where(p => p.Cpf == cpf);

            if (excludeId.HasValue)
                query = query.Where(p => p.Id != excludeId.Value);

            return await query.AnyAsync();
        }
    }
}