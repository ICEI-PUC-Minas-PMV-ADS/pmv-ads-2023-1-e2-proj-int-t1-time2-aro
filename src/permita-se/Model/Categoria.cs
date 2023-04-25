using permita_se.Data.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("categoria")]
    public partial class Categoria:IEntityBase
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
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"^(?!\s)[\p{L}0-9_\- ]+(?<!\s)$", ErrorMessage = "Caracteres inválidos no campo {0}")]
        public string Nome { get; set; }

        [Column("descricao")]
        [StringLength(255)]
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(255, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"^(?!\s)[\p{L}0-9_\- ]+(?<!\s)$", ErrorMessage = "Caracteres inválidos no campo {0}")]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Produto.Categoria))]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
