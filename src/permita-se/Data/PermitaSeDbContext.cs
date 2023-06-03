using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using permita_se.Model;

namespace permita_se.Data
{
    public partial class PermitaSeDbContext : IdentityDbContext<Usuario>
    {
        public PermitaSeDbContext(DbContextOptions<PermitaSeDbContext> options) : base(options)
        {
        }

        public virtual DbSet<CarrinhoItem> CarrinhoItems { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProduto });

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdProduto);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
