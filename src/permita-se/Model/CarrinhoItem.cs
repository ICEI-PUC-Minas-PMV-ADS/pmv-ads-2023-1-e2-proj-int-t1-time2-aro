using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    public partial class CarrinhoItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

        public string IdCarrinho { get; set; }

        //Produto
        public int IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }
    }
}
