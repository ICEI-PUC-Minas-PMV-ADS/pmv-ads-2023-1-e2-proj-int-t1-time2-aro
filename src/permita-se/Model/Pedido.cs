using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("pedido")]
    public partial class Pedido
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("data_pedido", TypeName = "date")]
        public DateTime DataPedido { get; set; }
        [Column("valor_total", TypeName = "decimal(10, 2)")]
        public decimal ValorTotal { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Model.Usuario.Pedidos))]
        public virtual Usuario Usuario { get; set; }

        [InverseProperty(nameof(PedidoItem.Pedido))]
        public virtual ICollection<PedidoItem> PedidoItems { get; set; }
    }
}
