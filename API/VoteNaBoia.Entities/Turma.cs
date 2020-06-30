using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        [Column("ID_Turma")]
        public int IDTurma { get; private set; }
        
        [Required]
        [Column("NM_Turma",TypeName ="varchar(255)")]
        public string NMTurma { get; private set; }

        [Required]
        [Column("CD_Turma")]
        public int CDTurma { get; private set; }

        [Required]
        [Column("DT_Criacao")]
        public DateTime DTCriacao { get; private set; }

     //   public  List<Restaurante> Restaurante { get; set; }

        protected Turma() { }

        public Turma(int id, string nome, int cod, DateTime dataCriacao)
        {
            this.IDTurma = id;
            this.NMTurma = nome;
            this.CDTurma = cod;
            this.DTCriacao = dataCriacao;
        }

    }
}
