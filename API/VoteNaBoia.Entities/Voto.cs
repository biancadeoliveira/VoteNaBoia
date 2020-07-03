using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities
{
    public class Voto
    {
        public int idTurma { get; set; }
        public int idRestaurante { get; set; }
        public int idAluno { get; set; }

        protected Voto() { }

        public Voto(int idTurma, int idRestaurante,int idAluno) 
        {
            this.idAluno = idAluno;
            this.idTurma = idTurma;
            this.idRestaurante = idRestaurante;
        }
    }
}
