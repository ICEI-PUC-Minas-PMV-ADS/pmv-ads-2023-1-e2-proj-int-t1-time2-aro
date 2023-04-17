using System.ComponentModel.DataAnnotations;

namespace permita_se.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}
