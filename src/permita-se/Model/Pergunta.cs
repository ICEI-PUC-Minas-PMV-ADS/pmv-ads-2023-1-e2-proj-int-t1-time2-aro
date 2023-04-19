using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("pergunta")]
    public partial class Pergunta
    {
        public Pergunta()
        {
            OpcaoResposta = new HashSet<OpcaoResposta>();
            PerguntaQuestionarios = new HashSet<PerguntaQuestionario>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("texto")]
        [StringLength(255)]
        public string Texto { get; set; }

        [InverseProperty(nameof(Model.OpcaoResposta.IdPerguntaNavigation))]
        public virtual ICollection<OpcaoResposta> OpcaoResposta { get; set; }
        [InverseProperty(nameof(PerguntaQuestionario.IdPerguntaNavigation))]
        public virtual ICollection<PerguntaQuestionario> PerguntaQuestionarios { get; set; }
    }
}
