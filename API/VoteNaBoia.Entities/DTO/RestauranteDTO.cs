using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class RestauranteDTO
    {
       
        public int IDRestaurante { get; set; }
        public int IDTurma { get; set; }
        public string NMNome { get; set; }
        public string NMTipo { get; set; }
        public string Endereco { get; set; }
        public string NOTelefone { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public char SNAtivo { get; set; }

        public Turma Turma { get; set; }

        public ICollection<PagamentoRestaurante> PagamentoRestaurante { get; set; }

    }
}
