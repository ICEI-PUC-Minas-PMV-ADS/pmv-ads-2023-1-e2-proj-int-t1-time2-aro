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
        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail é necessário")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é necessária")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$", ErrorMessage = "A senha deve conter no mínimo 6 caracteres, uma letra maiúscula, uma minúscula, um número e um caractere especial.")]
        public string Senha { get; set; }


        [Display(Name = "Confirma Senha")]
        [Required(ErrorMessage = "Confirmação de senha é necessária")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem." )]
        public string ConfirmaSenha { get; set; }

    }
}
