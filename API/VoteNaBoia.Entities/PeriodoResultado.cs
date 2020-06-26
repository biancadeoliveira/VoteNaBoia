using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Periodos_Resultados")]
    public class PeriodoResultado
    {
        [Key]
        [Column("ID_Periodo_Resultado")]
        public int IDPeriodoResultado { get; set; }

        [Required]
        [Column("ID_Restaurante")]
        public int IDRestaurante { get; set; }

        [Required]
        [Column("ID_Periodo")]
        public int IDPeriodo { get; set; }

        [Required]
        [Column("NO_Votos")]
        public int NOVotos { get; set; }

        [Required]
        [Column("SN_Visitado")]
        public char SNVisitado { get; set; }

        [Required]
        [Column("DT_Visita")]
        public DateTime DTVisita { get; set; }

        public PeriodoResultado() { }

        public PeriodoResultado(int IDPeriodoResultado, int IDRestaurante, int IDPeriodo, int NOVotos, char SNVisitado, DateTime DTVisita)
        {
            this.IDPeriodoResultado = IDPeriodoResultado;
            this.IDRestaurante = IDRestaurante;
            this.IDPeriodo = IDPeriodo;
            this.NOVotos = NOVotos;
            this.SNVisitado = SNVisitado;
            this.DTVisita = DTVisita;
        }
    }
}
