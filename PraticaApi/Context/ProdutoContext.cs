using Microsoft.EntityFrameworkCore;
using PraticaApi.Classes;

namespace PraticaApi.Context
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
            
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
