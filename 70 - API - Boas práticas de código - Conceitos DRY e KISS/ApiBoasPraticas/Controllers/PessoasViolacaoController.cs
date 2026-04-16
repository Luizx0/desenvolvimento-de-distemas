using Microsoft.AspNetCore.Mvc;
using ApiBoasPraticas.Services;
using ApiBoasPraticas.DTOs;

namespace ApiBoasPraticas.Controllers
{
    /// <summary>
    /// Controller que demonstra VIOLAÇÕES dos princípios DRY e KISS
    /// Criado apenas para fins didáticos de comparação
    /// </summary>
    [ApiController]
    [Route("api/pessoas/violacao")]
    public class PessoasViolacaoController : ControllerBase
    {
        private readonly PessoaServiceViolacao _serviceViolacao;

        public PessoasViolacaoController(PessoaServiceViolacao serviceViolacao)
        {
            _serviceViolacao = serviceViolacao;
        }

        /// <summary>
        /// POST api/pessoas/violacao/dry
        /// Demonstra violação do princípio DRY
        /// Código duplicado e complexo
        /// </summary>
        [HttpPost("dry")]
        [ProducesResponseType(typeof(PessoaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateViolandoDRY([FromBody] CreatePessoaDto dto)
        {
            try
            {
                // Método que viola DRY - validações duplicadas
                var pessoa = await _serviceViolacao.CriarPessoaComMultiplasValidacoes(dto);
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
        /// POST api/pessoas/violacao/kiss
        /// Demonstra violação do princípio KISS
        /// Método complexo com múltiplas responsabilidades
        /// </summary>
        [HttpPost("kiss")]
        [ProducesResponseType(typeof(PessoaDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateViolandoKISS([FromBody] ViolacaoKISSRequest request)
        {
            try
            {
                // Método que viola KISS - faz tudo de uma vez
                var pessoa = await _serviceViolacao.CriarPessoaComMultiplasValidacoes(
                    request.Pessoa,
                    request.ValidarCpfRemoto,
                    request.EnviarEmailConfirmacao,
                    request.GerarRelatorio,
                    request.NotificarAdministrador
                );
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
        /// Método auxiliar para redirecionamento
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetById(int id)
        {
            return RedirectToAction("GetById", "Pessoas", new { id });
        }
    }

    /// <summary>
    /// DTO para demonstrar violação KISS
    /// Múltiplos parâmetros booleanos = complexidade desnecessária
    /// </summary>
    public class ViolacaoKISSRequest
    {
        public CreatePessoaDto Pessoa { get; set; }

        // Parâmetros que violam KISS - método faz tudo
        public bool ValidarCpfRemoto { get; set; }
        public bool EnviarEmailConfirmacao { get; set; }
        public bool GerarRelatorio { get; set; }
        public bool NotificarAdministrador { get; set; }
    }
}