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
            OpcoesRespostas = new HashSet<OpcaoResposta>();
            PerguntasQuestionarios = new HashSet<PerguntaQuestionario>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("texto")]
        [StringLength(255)]
        public string Texto { get; set; }

        [InverseProperty(nameof(Model.OpcaoResposta.Pergunta))]
        public virtual ICollection<OpcaoResposta> OpcoesRespostas { get; set; }

        [InverseProperty(nameof(PerguntaQuestionario.Pergunta))]
        public virtual ICollection<PerguntaQuestionario> PerguntasQuestionarios { get; set; }
    }
}
