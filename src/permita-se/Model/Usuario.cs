using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    public partial class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataNascimento{ get; set; }

        public string Telefone { get; set; }

        //Relacionamentos
        [InverseProperty(nameof(Favorito.Usuario))]
        public virtual List<Favorito> Favoritos { get; set; }

        [InverseProperty(nameof(Pedido.Usuario))]
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
