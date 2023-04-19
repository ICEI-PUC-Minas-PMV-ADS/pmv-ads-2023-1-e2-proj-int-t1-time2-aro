using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("favoritos")]
    public partial class Favorito
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Key]
        [Column("id_produto")]
        public int IdProduto { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.Favoritos))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Favoritos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
