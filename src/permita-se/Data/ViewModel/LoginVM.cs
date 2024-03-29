﻿using System.ComponentModel.DataAnnotations;

namespace permita_se.Data.ViewModel
{
    public class LoginVM
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage ="E-mail é necessário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é necessário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
