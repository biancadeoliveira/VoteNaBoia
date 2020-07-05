using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface ILoginRepository:IRepository
    {
        Task<Aluno> GetAlunoLoginAsync(string email, string senha);
    }
}
