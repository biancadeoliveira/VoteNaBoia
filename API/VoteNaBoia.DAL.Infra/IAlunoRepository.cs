using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IAlunoRepository:IRepository
    {
        Task<Aluno> GetAlunoAsync(int IDAluno);
        Task<List<Aluno>> GetAllAlunoAsync();
        void CreateAlunoAsync(Aluno aluno);
        void UpdateAlunoAsync(Aluno aluno);
    }
}
