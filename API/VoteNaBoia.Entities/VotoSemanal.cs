using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Votos_Semanais")]
    public class VotoSemanal
    {
        [Key]
        [Column("ID_Voto_Semanal")]
        public int IDVotoSemanal { get; set; }
        [Required]
        [Column("ID_Restaurante")]
        public int IDRestaurante { get; set; }
        [Required]
        [Column("ID_Periodo")]
        public int IDPeriodo { get; set; }
        [Required]
        [Column("ID_Turma_Aluno")]
        public int IDTurmaAluno { get; set; }
        [Required]
        [Column("DH_Inclusao")]
        public DateTime DHInclusao { get; set; }

        public VotoSemanal() { }

        public VotoSemanal(int IDVotoSemanal, int IDRestaurante, int IDPeriodo, int IDTurmaAluno, DateTime DHInclusao)
        {
            this.IDVotoSemanal = IDVotoSemanal;
            this.IDRestaurante = IDRestaurante;
            this.IDPeriodo = IDPeriodo;
            this.IDTurmaAluno = IDTurmaAluno;
            this.DHInclusao = DHInclusao;
        }
    }
}
