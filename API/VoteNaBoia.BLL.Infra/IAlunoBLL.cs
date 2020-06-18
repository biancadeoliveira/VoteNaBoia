using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IAlunoBLL:IDisposable
    {
        Task<Aluno> GetAlunoAsync(int IDAluno);
        Task<List<Aluno>> GetAllAlunoAsync();
        Task CreateAlunoAsync(Aluno aluno);
        Task UpdateAlunoAsync(Aluno aluno);
        Task<string> UpdateStatusAlunoAsync(int IDAluno, char SNAtivo);
    }
}
