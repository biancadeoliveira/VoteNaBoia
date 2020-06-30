using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class VotoSemanalDTO
    {
        public int IDVotoSemanal { get; set; }
        public int IDRestaurante { get; set; }
        public int IDPeriodo { get; set; }
        public int IDTurmaAluno { get; set; }
        public DateTime DHInclusao { get; set; }
    }
}
