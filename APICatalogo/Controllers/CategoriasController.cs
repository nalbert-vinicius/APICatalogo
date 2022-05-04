using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogoContext _context;

        public CategoriasController(APICatalogoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categoria.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<IEnumerable<Categoria>> GetById(int id)
        {
            var categoria = _context.Categoria.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
            if(categoria == null)
            {
                return NotFound("Categoria não encontrada.....");
            }

            return Ok(categoria);
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaAndProdutos()
        {
            var categorias = _context.Categoria.Include(p => p.Produtos).AsNoTracking().ToList();
            return Ok(categorias);
        }



        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if(categoria == null)
            {
                return BadRequest("Insira todos os dados do produto!");
            }

            _context.Categoria.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new {id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Categoria.Update(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null) 
            {
                return NotFound("Categoria não encontrada...");
            }
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return Ok();
        }

    }
}
