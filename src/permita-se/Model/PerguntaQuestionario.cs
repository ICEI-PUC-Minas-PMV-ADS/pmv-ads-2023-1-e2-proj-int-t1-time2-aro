using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("pergunta_questionario")]
    public partial class PerguntaQuestionario
    {
        [Key]
        [Column("id_questionario")]
        public int IdQuestionario { get; set; }
        [Key]
        [Column("id_pergunta")]
        public int IdPergunta { get; set; }

        [ForeignKey(nameof(IdPergunta))]
        [InverseProperty(nameof(Pergunta.PerguntaQuestionarios))]
        public virtual Pergunta IdPerguntaNavigation { get; set; }
        [ForeignKey(nameof(IdQuestionario))]
        [InverseProperty(nameof(Questionario.PerguntaQuestionarios))]
        public virtual Questionario IdQuestionarioNavigation { get; set; }
    }
}
