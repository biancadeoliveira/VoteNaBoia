using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class TurmaBLL : ITurmaBLL
    {
        private readonly ITurmaRepository _turmaRepository;
        public TurmaBLL(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public void Dispose()
        {
            _turmaRepository?.Dispose();
        }

        public bool isTurmaCadastrada(int idTurma) 
        {
            var turma = _turmaRepository.GetTurmaByIDAsync(idTurma);
            if(turma != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
