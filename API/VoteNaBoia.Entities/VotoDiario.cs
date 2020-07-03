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
        public int IDVotoDiario { get;  set; }

        [Required]
        [Column("ID_Periodo_Resultado")]
        public int IDPeriodoResultado { get;  set; }

        [Required]
        [Column("ID_Turma_Aluno")]
        public int IDTurmaAluno { get;  set; }

        [Column("ID_Periodo_Diario")]
        public int IDPeriodoDiario { get; set; }

        [Required]
        [Column("DH_Inclusao")]
        public DateTime DHInclusao { get;  set; }

        protected VotoDiario() { }

        public VotoDiario(int id, int idPeriodoResultado, int idTurmaAluno, DateTime dataHora, int idPeriodoDiario) 
        {
            this.IDVotoDiario = id;
            this.IDPeriodoResultado = idPeriodoResultado;
            this.IDTurmaAluno = idTurmaAluno;
            this.DHInclusao = dataHora;
            this.IDPeriodoDiario = idPeriodoDiario;
        }

    }
}
