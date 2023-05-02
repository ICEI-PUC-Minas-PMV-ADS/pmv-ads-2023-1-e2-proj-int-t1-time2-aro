using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("carrinho_item")]
    public partial class CarrinhoItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_produto")]
        public int IdProduto { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Model.Produto.CarrinhoItems))]
        public virtual Produto Produto { get; set; }
    }
}
