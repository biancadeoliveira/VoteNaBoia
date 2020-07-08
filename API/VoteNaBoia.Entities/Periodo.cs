using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Periodos")]
    public class Periodo
    {
        [Key]
        [Column("ID_Periodo")]
        public int IDPeriodo { get; set; }

        [Required]
        [Column("ID_Turma")]
        public int IDTurma { get; set; }
        
        [Required]
        [Column("DH_Inicio")]
        public DateTime DHInicio { get; set; }

        [AllowNull]
        [Column("DH_Fim")]
        public DateTime DHFim { get; set; }

        [Required]
        [Column("SN_Ativo", TypeName = "char(1)")]
        public char SNAtivo { get; set; }

        [Required]
        [Column("SN_Processado", TypeName = "char(1)")]
        public char SNProcessado { get; set; }

        public Periodo() { }

        public Periodo(int IDPeriodo, int IDTurma, DateTime DHInicio, DateTime DHFim, char SNAtivo, char SNProcessado)
        {
            this.IDPeriodo = IDPeriodo;
            this.IDTurma = IDTurma;
            this.DHInicio = DHInicio;
            this.DHFim = DHFim;
            this.SNAtivo = SNAtivo;
            this.SNProcessado = SNProcessado;
        }

    }
}
