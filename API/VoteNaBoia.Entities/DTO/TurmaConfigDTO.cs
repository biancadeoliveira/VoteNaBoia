using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class TurmaConfigDTO
    {
        public int IDTurmaConfig { get; private set; }
        public int IDTurma { get; set; }

        public char SNSegunda { get; set; }

        public char SNTerca { get; set; }

        public char SNQuarta { get; set; }
   
        public char SNQuinta { get; set; }

        public char SNSexta { get; set; }
 
        public char SNSabado { get; set; }

        public int NORestaurantesDescVTSemanal { get; set; }

        public int NODiaVTSemanal { get; set; }

        public DateTime DHInicioVTSemanal { get; set; }

        public DateTime DHTerminoVTSemanal { get; set; }

        public DateTime DHInicioVTDiaria { get; set; }

        public DateTime DHTerminoVTDiaria { get; set; }
    }
}
