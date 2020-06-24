using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        [Column("ID_Avaliacao")]
        public int IDAvaliacao { get; private set; }

        [Required]
        [ForeignKey("ID_Restaurante")]
        [Column("ID_Restaurante")]
        public int IDRestaurante { get; private set; }

        [Required]
        [ForeignKey("ID_Turma_Aluno")]
        [Column("ID_Turma_Aluno")]
        public int IDTurmaAluno { get; private set; }

        [Required]
        [Column("Nota")]
        public int Nota { get; set; }

        protected Avaliacao() { }

        public Avaliacao(int id, int idRestaurante, int idTurmaAluno, int nota) 
        {
            this.IDAvaliacao = id;
            this.IDRestaurante = idRestaurante;
            this.IDTurmaAluno = idTurmaAluno;
            this.Nota = nota;
        }
    }
}
