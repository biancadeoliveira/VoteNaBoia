using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.DAL.DataBaseContext;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL
{
    public class TurmaAlunoRepository : ITurmaAlunoRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public TurmaAlunoRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<List<TurmaAluno>> GetAllAlunosTurmaAsync(int IDTurma)
        {
            return await _dbContext.TurmaAluno.Where(x => x.IDTurma.Equals(IDTurma)).ToListAsync();
        }

        public async Task<List<TurmaAluno>> GetAllTurmasAlunoAsync(int IDAluno)
        {
            return await _dbContext.TurmaAluno.Where(x => x.IDAluno.Equals(IDAluno)).ToListAsync();
        }

        public async Task<TurmaAluno> GetTurmaAlunoAsync(int IDAluno, int IDTurma)
        {
            return await _dbContext.TurmaAluno.Where(x => x.IDAluno.Equals(IDAluno) && x.IDTurma.Equals(IDTurma)).FirstOrDefaultAsync();
        }

        public async Task<TurmaAluno> GetTurmaAlunoAsync(int IDTurmaAluno)
        {
            return await _dbContext.TurmaAluno.Where(x => x.IDAluno.Equals(IDTurmaAluno) && x.IDTurma.Equals(IDTurmaAluno)).FirstOrDefaultAsync();
        }

        public void LinkTurmaAlunoAsync(TurmaAluno turmaAluno)
        {
            _dbContext.TurmaAluno.Add(turmaAluno);
        }

        public void UpdateTurmaAlunoAsync(TurmaAluno turmaAluno)
        {
            bool isDetached = _dbContext.Entry(turmaAluno).State == EntityState.Detached;
            if (isDetached)
                _dbContext.TurmaAluno.Attach(turmaAluno);

            _dbContext.TurmaAluno.Update(turmaAluno);
        }
    }
}
