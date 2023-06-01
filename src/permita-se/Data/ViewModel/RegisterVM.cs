using System.ComponentModel.DataAnnotations;

namespace permita_se.Data.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Nome é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é necessário")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Telefone é necessário")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail é necessário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é necessária")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        [Display(Name = "Confirma Senha")]
        [Required(ErrorMessage = "Confirmação de senha é necessária")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem." )]
        public string ConfirmaSenha { get; set; }

    }
}
