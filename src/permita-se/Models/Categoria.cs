using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace permita_se.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
