using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoteNaBoia.DAL.DataBaseContext;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public TurmaRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;


        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<Turma> GetTurmaByIDAsync(int idTurma)
        {
            return await _dbContext.Turma.Where(x => x.IDTurma.Equals(idTurma)).FirstOrDefaultAsync();
        }
    }
}
