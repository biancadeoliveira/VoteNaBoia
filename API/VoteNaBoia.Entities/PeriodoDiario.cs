using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Periodos_Diarios")]
    public class PeriodoDiario
    {
        [Key]
        [Column("ID_Periodo_Diario")]
        public int IDPeriodoDiario { get; set; }

        [Required]
        [Column("ID_Periodo")]
        public int IDPeriodo { get; set; }

        [Required]
        [Column("DH_Inicio")]
        public DateTime DHInicio { get; set; }

        [AllowNull]
        [Column("DH_Fim")]
        public DateTime DHFim { get; set; }

        [Required]
        [Column("SN_Ativo", TypeName = "char(1)")]
        public char SNAtivo { get; set; }

        public PeriodoDiario() { }

        public PeriodoDiario(int IDPeriodoDiario, int IDPeriodo, DateTime DHInicio, DateTime DHFim, char SNAtivo)
        {
            this.IDPeriodoDiario = IDPeriodoDiario;
            this.IDPeriodo = IDPeriodo;
            this.DHInicio = DHInicio;
            this.DHFim = DHFim;
            this.SNAtivo = SNAtivo;
        }

    }
}
