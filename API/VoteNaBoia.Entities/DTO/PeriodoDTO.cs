using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class PeriodoDTO
    {
        public int IDPeriodo { get; set; }
        public int IDTurma { get; set; }
        public DateTime DHInicio { get; set; }
        public DateTime DHFim { get; set; }
        public char SNAtivo { get; set; }
        public char SNProcessado { get; set; }
    }
}
