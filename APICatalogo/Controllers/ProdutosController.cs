using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APICatalogoContext _context;

        //Injetando o contexto
        public ProdutosController(APICatalogoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produto.AsNoTracking().ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não foram encontrados!!");
            }
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Insira todos os dados do produto!");
            }

            _context.Produto.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Update(produto);
            _context.SaveChanges();
            return Ok(produto);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não localizado....");
            }

            _context.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
