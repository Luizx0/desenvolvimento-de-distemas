using Microsoft.AspNetCore.Mvc;
using ApiEncapsulamento.Models;
using ApiEncapsulamento.Data;

namespace ApiEncapsulamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _repository;

        public UsuariosController(UsuarioRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// GET api/usuarios
        /// Lista todos os usuários ativos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), 200)]
        public IActionResult GetUsuarios()
        {
            try
            {
                var usuarios = _repository.ObterTodos();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno do servidor", detalhes = ex.Message });
            }
        }

        /// <summary>
        /// GET api/usuarios/{id}
        /// Obtém um usuário específico por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetUsuario(int id)
        {
            try
            {
                var usuario = _repository.ObterPorId(id);
                if (usuario == null)
                    return NotFound(new { erro = "Usuário não encontrado" });

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno do servidor", detalhes = ex.Message });
            }
        }

        /// <summary>
        /// POST api/usuarios
        /// Cria um novo usuário
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(400)]
        public IActionResult PostUsuario([FromBody] UsuarioInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Cria usuário usando construtor com validação
                var usuario = new Usuario(model.Nome, model.Email, model.DataNascimento);

                // Adiciona ao repositório
                var usuarioCriado = _repository.Adicionar(usuario);

                return CreatedAtAction(
                    nameof(GetUsuario),
                    new { id = usuarioCriado.Id },
                    usuarioCriado
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = "Dados inválidos", detalhes = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno do servidor", detalhes = ex.Message });
            }
        }

        /// <summary>
        /// PUT api/usuarios/{id}
        /// Atualiza um usuário existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult PutUsuario(int id, [FromBody] UsuarioInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Cria objeto temporário para validação
                var usuarioAtualizado = new Usuario(model.Nome, model.Email, model.DataNascimento);

                // Atualiza no repositório
                var sucesso = _repository.Atualizar(id, usuarioAtualizado);
                if (!sucesso)
                    return NotFound(new { erro = "Usuário não encontrado" });

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = "Dados inválidos", detalhes = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno do servidor", detalhes = ex.Message });
            }
        }

        /// <summary>
        /// DELETE api/usuarios/{id}
        /// Remove um usuário (soft delete)
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var sucesso = _repository.Remover(id);
                if (!sucesso)
                    return NotFound(new { erro = "Usuário não encontrado" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno do servidor", detalhes = ex.Message });
            }
        }
    }

    /// <summary>
    /// Modelo de entrada para criação/atualização de usuários
    /// </summary>
    public class UsuarioInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}