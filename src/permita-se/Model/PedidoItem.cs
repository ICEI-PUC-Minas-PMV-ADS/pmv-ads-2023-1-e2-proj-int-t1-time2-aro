using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    public partial class PedidoItem
    {
        [Key]
        public int Id { get; set; }
        
        public int Quantidade { get; set; }
        
        public double Preco { get; set; }

        public int IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }

        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }
    }
}
