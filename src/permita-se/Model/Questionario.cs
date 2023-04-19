﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace permita_se.Model
{
    [Table("questionario")]
    public partial class Questionario
    {
        public Questionario()
        {
            PerguntaQuestionarios = new HashSet<PerguntaQuestionario>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("titulo")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [InverseProperty(nameof(PerguntaQuestionario.IdQuestionarioNavigation))]
        public virtual ICollection<PerguntaQuestionario> PerguntaQuestionarios { get; set; }
    }
}