using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    public partial class Pedido
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime DataPedido { get; set; }
        
        public double ValorTotal { get; set; }
        
        public string IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public virtual Usuario Usuario { get; set; }

             //Relacionamento Pedido-PedidoItem
        public virtual List<PedidoItem> PedidoItems { get; set; }
    }
}
