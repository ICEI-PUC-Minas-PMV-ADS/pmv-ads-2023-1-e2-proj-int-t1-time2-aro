using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Favoritos = new HashSet<Favorito>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(20)]
        public string Senha { get; set; }
        [Column("idade")]
        public int? Idade { get; set; }
        [Column("telefone")]
        [StringLength(20)]
        public string Telefone { get; set; }
        [Column("gerente")]
        public bool? Gerente { get; set; }

        [InverseProperty(nameof(Favorito.IdUsuarioNavigation))]
        public virtual ICollection<Favorito> Favoritos { get; set; }
    }
}
