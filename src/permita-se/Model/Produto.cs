using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("produto")]
    public partial class Produto
    {
        public Produto()
        {
            CarrinhoItems = new HashSet<CarrinhoItem>();
            Favoritos = new HashSet<Favorito>();
            PedidoItems = new HashSet<PedidoItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("descricao")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Column("preco", TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        [Column("imagem_url")]
        [StringLength(255)]
        public string ImagemUrl { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Model.Categoria.Produtos))]
        public virtual Categoria Categoria { get; set; }

        [InverseProperty(nameof(CarrinhoItem.Produto))]
        public virtual ICollection<CarrinhoItem> CarrinhoItems { get; set; }

        [InverseProperty(nameof(Favorito.Produto))]
        public virtual ICollection<Favorito> Favoritos { get; set; }

        [InverseProperty(nameof(PedidoItem.Produto))]
        public virtual ICollection<PedidoItem> PedidoItems { get; set; }
    }
}
