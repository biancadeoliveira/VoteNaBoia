using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface ITurmaAlunoBLL : IDisposable
    {
        Task<List<TurmaAluno>> GetAllAlunosTurmaAsync(int IDTurma);
        Task<List<TurmaAluno>> GetAllTurmasAlunoAsync(int IDAluno);
        Task<TurmaAluno> GetTurmaAlunoAsync(int IDTurmaAluno);
        Task<TurmaAluno> GetTurmaAlunoAsync(int IDAluno, int IDTurma);
        Task LinkTurmaAlunoAsync(TurmaAluno turmaAluno);
        Task UpdateTurmaAlunoAsync(TurmaAluno turmaAluno);
    }
}
