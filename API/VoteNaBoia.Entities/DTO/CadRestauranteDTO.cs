using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class CadRestauranteDTO
    {
        public int RestId { get; set; }
        public int RestIdTurma { get; set; }
        public string RestNome { get; set; }
        public string RestTipo { get; set; }
        public string RestEndereco { get; set; }
        public string RestTelefone { get; set; }
        public string RestLink { get; set; }
        public string RestEmail { get; set; }
        public string RestAtivo { get; set; }

    }
}
