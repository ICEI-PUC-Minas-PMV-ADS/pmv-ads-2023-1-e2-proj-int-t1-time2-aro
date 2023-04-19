using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("categoria")]
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
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

        [InverseProperty(nameof(Produto.IdCategoriaNavigation))]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
