using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface ITurmaRepository:IRepository
    {
        Task<Turma> GetTurmaByIDAsync(int idTurma);
    }
}
