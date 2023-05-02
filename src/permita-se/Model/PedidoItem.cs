using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("pedido_item")]
    public partial class PedidoItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_produto")]
        public int IdProduto { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Model.Produto.PedidoItems))]
        public virtual Produto Produto { get; set; }
    }
}
