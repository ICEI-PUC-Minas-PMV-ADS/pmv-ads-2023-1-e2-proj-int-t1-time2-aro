using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("opcao_resposta")]
    public partial class OpcaoResposta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_pergunta")]
        public int IdPergunta { get; set; }
        [Column("texto")]
        [StringLength(255)]
        public string Texto { get; set; }

        [ForeignKey(nameof(IdPergunta))]
        [InverseProperty(nameof(Pergunta.OpcaoResposta))]
        public virtual Pergunta IdPerguntaNavigation { get; set; }
    }
}
