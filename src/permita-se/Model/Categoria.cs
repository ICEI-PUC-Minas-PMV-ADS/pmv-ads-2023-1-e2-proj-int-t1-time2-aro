using permita_se.Data.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace permita_se.Model
{
    public partial class Categoria:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"^(?!\s)[\p{L}0-9_\- ]+(?<!\s)$", ErrorMessage = "Caracteres inválidos no campo {0}")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(255, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"^(?!\s)[\p{L}0-9_\- ]+(?<!\s)$", ErrorMessage = "Caracteres inválidos no campo {0}")]
        public string Descricao { get; set; }

        //Relacionamento Categoria-Produto
        public virtual List<Produto> Produtos { get; set; }
    }
}
