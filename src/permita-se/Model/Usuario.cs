using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 57250059651b921ef597ddfeb1581736571e723f
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
<<<<<<< HEAD
    [Table("usuario")]
    public partial class Usuario : IdentityUser   
=======
    public partial class Usuario:IdentityUser
>>>>>>> 57250059651b921ef597ddfeb1581736571e723f
    {
        public string Nome { get; set; }
        
        public int Idade { get; set; }
        
        public string Telefone { get; set; }

        //Relacionamentos
        [InverseProperty(nameof(Favorito.Usuario))]
        public virtual List<Favorito> Favoritos { get; set; }

        [InverseProperty(nameof(Pedido.Usuario))]
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
