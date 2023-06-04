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
        [MaxLength(100)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        public string ImagemUrl { get; set; }

        //Relacionamento Categoria-Produto
        public virtual List<Produto> Produtos { get; set; }
    }
}
