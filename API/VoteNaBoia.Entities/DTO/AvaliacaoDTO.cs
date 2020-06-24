using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class AvaliacaoDTO
    {
        public int IDAvaliacao { get; set; }
        public int IDRestaurante { get; set; }
        public int IDTurmaAluno { get; set; }
        public int Nota { get; set; }
    }
}
