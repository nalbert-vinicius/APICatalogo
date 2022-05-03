using Microsoft.EntityFrameworkCore;
using APICatalogo.Models;

namespace APICatalogo.Context
{
    public class APICatalogoContext : DbContext
    {
        //Config do contexto
        public APICatalogoContext(DbContextOptions<APICatalogoContext> options) : base(options)
        {

        }

        //Set das tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produto { get; set; }

    }
}
