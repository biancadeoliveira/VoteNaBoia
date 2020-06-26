using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class PeriodoResultadoDTO
    {
        public int IDPeriodoResultado { get; set; }
        public int IDRestaurante { get; set; }
        public int IDPeriodo { get; set; }
        public int NOVotos { get; set; }
        public char SNVisitado { get; set; }
        public DateTime DTVisita { get; set; }
    }
}
