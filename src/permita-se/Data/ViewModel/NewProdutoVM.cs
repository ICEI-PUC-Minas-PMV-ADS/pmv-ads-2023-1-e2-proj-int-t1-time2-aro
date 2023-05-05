using permita_se.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Models
{
    public class NewProdutoVM

    {   
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "Nome do produto é necessária")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do produto")]
        [Required(ErrorMessage = "Descrição do produto é necessária")]
        public string Descricao { get; set; }

        [Display(Name = "Preço do produto")]
        [Required(ErrorMessage = "Preço do produto é necessária")]
        public decimal Preco { get; set; }

        [Display(Name = "Imagem do produto")]
        [Required(ErrorMessage = "Imagem do produto é necessária")]
        public string ImagemURL { get; set; }

        [Display(Name = "Selecione a categoria do produto")]
        [Required(ErrorMessage = "Categoria do produto é necessária")]
        public int IdCategoria { get; set; }

    }
}
