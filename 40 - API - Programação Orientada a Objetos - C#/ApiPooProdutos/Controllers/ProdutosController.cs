using ApiPooProdutos.Models;
using ApiPooProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPooProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoService produtoService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(produtoService.Listar());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var produto = produtoService.BuscarPorId(id);
        if (produto is null)
        {
            return NotFound(new { mensagem = $"Produto com id {id} nao foi encontrado." });
        }

        return Ok(produto);
    }

    [HttpPost("comum")]
    public IActionResult PostComum([FromBody] CriarProdutoComumRequest request)
    {
        var produtoCriado = produtoService.AdicionarComum(request);
        return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);
    }

    [HttpPost("eletronico")]
    public IActionResult PostEletronico([FromBody] CriarProdutoEletronicoRequest request)
    {
        var produtoCriado = produtoService.AdicionarEletronico(request);
        return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, produtoCriado);
    }
}
