using permita_se.Data.Base;
using permita_se.Data.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    public class Produto:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }

        public string ImagemUrl { get; set; }

        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        public ProdutoStatus ProdutoStatus { get; set; }

        [NotMapped]
        public bool IsFavorito { get; set; }



        //Relacionamentos
        public virtual List<CarrinhoItem> CarrinhoItems { get; set; }

        public virtual List<Favorito> Favoritos { get; set; }

        public virtual List<PedidoItem> PedidoItems { get; set; }
    }
}
