using permita_se.Data.Services;
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
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Column("preco", TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Model.Produto.PedidoItems))]
        public virtual Produto Produto { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(Model.Pedido.PedidoItems))]
        public virtual Pedido Pedido { get; set; }
    }
}
