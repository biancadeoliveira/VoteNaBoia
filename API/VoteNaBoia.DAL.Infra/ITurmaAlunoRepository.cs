using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface ITurmaAlunoRepository:IRepository
    {
        Task<TurmaAluno> GetTurmaAlunoAsync(int IDTurmaAluno);
        Task<TurmaAluno> GetTurmaAlunoAsync(int IDAluno, int IDTurma);
        Task<List<TurmaAluno>> GetAllTurmasAlunoAsync(int IDAluno);
        Task<List<TurmaAluno>> GetAllAlunosTurmaAsync(int IDTurma);
        void LinkTurmaAlunoAsync(TurmaAluno turmaAluno);
        void UpdateTurmaAlunoAsync(TurmaAluno turmaAluno);
    }
}
