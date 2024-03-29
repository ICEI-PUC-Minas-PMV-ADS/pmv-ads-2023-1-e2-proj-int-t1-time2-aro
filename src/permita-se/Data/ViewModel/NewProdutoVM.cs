﻿using Microsoft.AspNetCore.Http;
using permita_se.Data.Enum;
using System.ComponentModel.DataAnnotations;


namespace permita_se.Data.ViewModel
{
    public class NewProdutoVM

    {   
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"^(?!\s)[\p{L}0-9_\- ]+(?<!\s)$", ErrorMessage = "Caracteres inválidos no campo {0}")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        [MaxLength(60, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"^(?!\s)[\p{L}0-9_\- ]+(?<!\s)$", ErrorMessage = "Caracteres inválidos no campo {0}")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^[0-9]*(\,[0-9]{0,2})?$", ErrorMessage = "Valor inválido! Preço deve estar no formato ##,##")]
        public string Preco { get; set; }

        public string ImagemURL { get; set; }

        [Display(Name = "Imagem do produto")]
        public IFormFile ImagemUpload { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdCategoria { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ProdutoStatus ProdutoStatus { get; set; }

    }
}
