
using Microsoft.EntityFrameworkCore;
using permita_se.Models;

namespace permita_se.Data
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
       
    }
    
}
