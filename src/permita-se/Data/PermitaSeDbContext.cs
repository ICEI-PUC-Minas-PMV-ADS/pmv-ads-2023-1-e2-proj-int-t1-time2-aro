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

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<OpcaoResposta> OpcaoResposta { get; set; }
        public virtual DbSet<PerguntaQuestionario> PerguntaQuestionarios { get; set; }
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

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProduto })
                    .HasName("PK__favorito__D59D8EC601C60CFF");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favoritos__id_pr__6477ECF3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favoritos__id_us__6383C8BA");
            });

            modelBuilder.Entity<OpcaoResposta>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.OpcaoResposta)
                    .HasForeignKey(d => d.IdPergunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__opcao_res__id_pe__6EF57B66");
            });

            modelBuilder.Entity<PerguntaQuestionario>(entity =>
            {
                entity.HasKey(e => new { e.IdQuestionario, e.IdPergunta })
                    .HasName("PK__pergunta__DC4D1DA718F174D8");

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.PerguntaQuestionarios)
                    .HasForeignKey(d => d.IdPergunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pergunta___id_pe__6C190EBB");

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.PerguntaQuestionarios)
                    .HasForeignKey(d => d.IdQuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pergunta___id_qu__6B24EA82");
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Texto).IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.ImagemUrl).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__produto__id_cate__60A75C0F");
            });

            modelBuilder.Entity<Questionario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Titulo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

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
