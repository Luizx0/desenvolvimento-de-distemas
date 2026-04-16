using System.Collections.Generic;
using System.Linq;
using ApiEncapsulamento.Models;

namespace ApiEncapsulamento.Data
{
    /// <summary>
    /// Repository para gerenciamento de usuários
    /// Simula operações de banco de dados em memória
    /// </summary>
    public class UsuarioRepository
    {
        private readonly List<Usuario> _usuarios;
        private int _proximoId;

        public UsuarioRepository()
        {
            _usuarios = new List<Usuario>();
            _proximoId = 1;
            InicializarDadosTeste();
        }

        /// <summary>
        /// Inicializa dados de teste
        /// </summary>
        private void InicializarDadosTeste()
        {
            var usuario1 = new Usuario("João Silva", "joao.silva@email.com", new DateTime(1990, 5, 15));
            usuario1.Id = _proximoId++;
            _usuarios.Add(usuario1);

            var usuario2 = new Usuario("Maria Santos", "maria.santos@email.com", new DateTime(1985, 8, 22));
            usuario2.Id = _proximoId++;
            _usuarios.Add(usuario2);

            var usuario3 = new Usuario("Pedro Oliveira", "pedro.oliveira@email.com", new DateTime(1995, 12, 10));
            usuario3.Id = _proximoId++;
            _usuarios.Add(usuario3);
        }

        /// <summary>
        /// Obtém todos os usuários
        /// </summary>
        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarios.Where(u => u.Ativo);
        }

        /// <summary>
        /// Obtém usuário por ID
        /// </summary>
        public Usuario ObterPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id && u.Ativo);
        }

        /// <summary>
        /// Adiciona novo usuário
        /// </summary>
        public Usuario Adicionar(Usuario usuario)
        {
            usuario.Id = _proximoId++;
            _usuarios.Add(usuario);
            return usuario;
        }

        /// <summary>
        /// Atualiza usuário existente
        /// </summary>
        public bool Atualizar(int id, Usuario usuarioAtualizado)
        {
            var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == id && u.Ativo);
            if (usuarioExistente == null)
                return false;

            // Atualiza os dados usando o método de encapsulamento
            usuarioExistente.AtualizarDados(
                usuarioAtualizado.Nome,
                usuarioAtualizado.Email,
                usuarioAtualizado.DataNascimento
            );

            return true;
        }

        /// <summary>
        /// Remove usuário (soft delete - desativa)
        /// </summary>
        public bool Remover(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id && u.Ativo);
            if (usuario == null)
                return false;

            usuario.AlterarStatus(false); // Usa método de encapsulamento
            return true;
        }

        /// <summary>
        /// Verifica se usuário existe
        /// </summary>
        public bool Existe(int id)
        {
            return _usuarios.Any(u => u.Id == id && u.Ativo);
        }

        /// <summary>
        /// Obtém total de usuários ativos
        /// </summary>
        public int ContarAtivos()
        {
            return _usuarios.Count(u => u.Ativo);
        }
    }
}