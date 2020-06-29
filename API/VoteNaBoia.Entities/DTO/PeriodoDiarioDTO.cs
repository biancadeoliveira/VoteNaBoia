using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class PeriodoDiarioDTO
    {
        public int IDPeriodoDiario { get; set; }
        public int IDPeriodo { get; set; }
        public DateTime DHInicio { get; set; }
        public DateTime DHFim { get; set; }
        public char SNAtivo { get; set; }
    }
}
