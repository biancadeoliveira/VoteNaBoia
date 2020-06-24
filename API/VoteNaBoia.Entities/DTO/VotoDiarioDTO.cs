using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class VotoDiarioDTO
    {
        public int IDVotoDiario { get; set; }
        public int IDPeriodoResultado { get; set; }
        public int IDTurmaAluno { get; set; }
        public DateTime DHInclusao { get; set; }
    }
}
