using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class TurmaAlunoBLL : ITurmaAlunoBLL
    {
        private readonly ITurmaAlunoRepository _turmaAlunoRepository;
        public TurmaAlunoBLL(ITurmaAlunoRepository turmaAlunoRepository)
        {
            _turmaAlunoRepository = turmaAlunoRepository;
        }

        public void Dispose()
        {
            _turmaAlunoRepository?.Dispose();
        }

        public async Task<List<TurmaAluno>> GetAllAlunosTurmaAsync(int IDTurma)
        {
            new List<TurmaAluno>();
            return await _turmaAlunoRepository.GetAllAlunosTurmaAsync(IDTurma);
        }

        public async Task<List<TurmaAluno>> GetAllTurmasAlunoAsync(int IDAluno)
        {
            new List<TurmaAluno>();
            return await _turmaAlunoRepository.GetAllTurmasAlunoAsync(IDAluno);
        }

        public async Task<TurmaAluno> GetTurmaAlunoAsync(int IDTurmaAluno)
        {
            return await _turmaAlunoRepository.GetTurmaAlunoAsync(IDTurmaAluno);
        }

        public async Task<TurmaAluno> GetTurmaAlunoAsync(int IDAluno, int IDTurma)
        {
            return await _turmaAlunoRepository.GetTurmaAlunoAsync(IDAluno, IDTurma);
        }

        public async Task LinkTurmaAlunoAsync(TurmaAluno turmaAluno)
        {
            _turmaAlunoRepository.LinkTurmaAlunoAsync(turmaAluno);
            await _turmaAlunoRepository.UnitOfWork.Commit();
        }

        public async Task UpdateTurmaAlunoAsync(TurmaAluno turmaAluno)
        {
            _turmaAlunoRepository.UpdateTurmaAlunoAsync(turmaAluno);
            await _turmaAlunoRepository.UnitOfWork.Commit();
        }
    }
}
