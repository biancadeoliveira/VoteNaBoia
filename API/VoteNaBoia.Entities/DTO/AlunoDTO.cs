using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class AlunoDTO
    {
        public int IDAluno { get; set; }
        public string NMAluno { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public char SNEnviaEmail { get; set; }
        public char SNAtivo { get; set; }
    }
}
