using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Votos_Diarios")]
    public class VotoDiario
    {
        [Key]
        [Column("ID_Voto_Diario")]
        public int IDVotoDiario { get; private set; }

        [Required]
        [ForeignKey("ID_Periodo_Resultado")]
        [Column("ID_Periodo_Resultado")]
        public int IDPeriodoResultado { get; private set; }

        [Required]
        [ForeignKey("ID_Turma_Aluno")]
        [Column("ID_Turma_Aluno")]
        public int IDTurmaAluno { get; private set; }

        [Required]
        [Column("DH_Inclusao")]
        public DateTime DHInclusao { get; private set; }

        protected VotoDiario() { }

        public VotoDiario(int id, int idPeriodoResultado, int idTurmaAluno, DateTime dataHora) 
        {
            this.IDVotoDiario = id;
            this.IDPeriodoResultado = idPeriodoResultado;
            this.IDTurmaAluno = idTurmaAluno;
            this.DHInclusao = dataHora;
        }




    }
}
