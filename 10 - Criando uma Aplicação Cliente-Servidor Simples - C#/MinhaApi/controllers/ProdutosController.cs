using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Mouse", Preco = 50 },
            new Produto { Id = 2, Nome = "Teclado", Preco = 120 },
            new Produto { Id = 3, Nome = "Monitor", Preco = 900 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(Produto novo)
        {
            novo.Id = produtos.Count + 1;
            produtos.Add(novo);
            return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
        }
    }
}