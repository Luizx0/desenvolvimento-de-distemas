using Microsoft.AspNetCore.Mvc;
using ApiBoasPraticas.Services;
using ApiBoasPraticas.DTOs;

namespace ApiBoasPraticas.Controllers
{
    /// <summary>
    /// Controller de Pessoas - Demonstra boas práticas KISS
    /// Métodos simples, delegação para serviços
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET api/pessoas
        /// Lista todas as pessoas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PessoaDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pessoas = await _service.ObterTodosAsync();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno", message = ex.Message });
            }
        }

        /// <summary>
        /// GET api/pessoas/{id}
        /// Obtém pessoa por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pessoa = await _service.ObterPorIdAsync(id);
                if (pessoa == null)
                    return NotFound(new { error = "Pessoa não encontrada" });

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno", message = ex.Message });
            }
        }

        /// <summary>
        /// POST api/pessoas
        /// Cria nova pessoa com validação DRY
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PessoaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreatePessoaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var pessoa = await _service.CriarAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = "Dados inválidos", message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno", message = ex.Message });
            }
        }

        /// <summary>
        /// PUT api/pessoas/{id}
        /// Atualiza pessoa existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PessoaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePessoaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var pessoa = await _service.AtualizarAsync(id, dto);
                return Ok(pessoa);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = "Dados inválidos", message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = "Pessoa não encontrada", message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno", message = ex.Message });
            }
        }

        /// <summary>
        /// DELETE api/pessoas/{id}
        /// Remove pessoa
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var removido = await _service.RemoverAsync(id);
                if (!removido)
                    return NotFound(new { error = "Pessoa não encontrada" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno", message = ex.Message });
            }
        }
    }
}