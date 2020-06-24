
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Turma_Aluno")]
    public class TurmaAluno
    {
        [Key]
        [Column("ID_Turma_Aluno")]
        public int IDTurmaAluno { get; set; }

        [Required]
        [Column("ID_Aluno")]
        public int IDAluno { get; set; }

        [Required]
        [Column("ID_Turma")]
        public int IDTurma { get; set; }

        [Required]
        [Column("DT_Vinculo")]
        public DateTime DTVinculo { get; set; }

        [Required]
        [Column("SN_Aprovado", TypeName = "char(1)")]
        public char SNAprovado { get; set; }

        [Required]
        [Column("SN_Moderador", TypeName = "char(1)")]
        public char SNModerador { get; set; }

        protected TurmaAluno() { }

        public TurmaAluno(int IDTurmaAluno, int IDAluno, int IDTurma, DateTime DTVinculo, char SNAprovado, char SNModerador)
        {
            this.IDTurmaAluno = IDTurmaAluno;
            this.IDAluno = IDAluno;
            this.IDTurma = IDTurma;
            this.DTVinculo = DTVinculo;
            this.SNAprovado = SNAprovado;
            this.SNModerador = SNModerador;
        }

        public void setSNAprovado(char SNAprovado)
        {
            this.SNAprovado = SNAprovado;
        }


    }
}
