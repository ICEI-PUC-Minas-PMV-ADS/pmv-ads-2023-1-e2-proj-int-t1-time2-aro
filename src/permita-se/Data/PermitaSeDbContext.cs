 using Microsoft.EntityFrameworkCore;
using permita_se.Model;


namespace permita_se.Data
{
    public partial class PermitaSeDbContext : DbContext
    {
        public PermitaSeDbContext()
        {
        }

        public PermitaSeDbContext(DbContextOptions<PermitaSeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarrinhoItem> CarrinhoItems { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<OpcaoResposta> OpcaoRespostas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }
        public virtual DbSet<PerguntaQuestionario> PerguntasQuestionarios { get; set; }
        public virtual DbSet<Pergunta> Perguntas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Questionario> Questionarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:pmv-ads-2023-1-e2-proj-int-t1-time2-aro.database.windows.net,1433;Initial Catalog=permita-se;Persist Security Info=False;User ID=permita-se;Password=P3rm!t4-se;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CarrinhoItem>(entity =>
            {
                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.CarrinhoItems)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrinho_item_produto");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProduto })
                    .HasName("PK__favorito__D59D8EC66B775EC9");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favoritos_produto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favoritos_usuario");
            });

            modelBuilder.Entity<OpcaoResposta>(entity =>
            {
                entity.Property(e => e.Texto).IsUnicode(false);

                entity.HasOne(d => d.Pergunta)
                    .WithMany(p => p.OpcoesRespostas)
                    .HasForeignKey(d => d.IdPergunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_opcao_resposta_pergunta");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_usuario");
            });

            modelBuilder.Entity<PedidoItem>(entity =>
            {
                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.PedidoItems)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_item_pedido");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.PedidoItems)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_item_produto");
            });

            modelBuilder.Entity<PerguntaQuestionario>(entity =>
            {
                entity.HasKey(e => new { e.IdQuestionario, e.IdPergunta })
                    .HasName("PK__pergunta__DC4D1DA74B233886");

                entity.HasOne(d => d.Pergunta)
                    .WithMany(p => p.PerguntasQuestionarios)
                    .HasForeignKey(d => d.IdPergunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pergunta_questionario_pergunta");

                entity.HasOne(d => d.Questionario)
                    .WithMany(p => p.PerguntasQuestionarios)
                    .HasForeignKey(d => d.IdQuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pergunta_questionario_questionario");
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.Property(e => e.Texto).IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.ImagemUrl).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_categoria");
            });

            modelBuilder.Entity<Questionario>(entity =>
            {
                entity.Property(e => e.Titulo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
