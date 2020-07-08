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
    public class PeriodoRepository : IPeriodoRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public PeriodoRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void AbrirPeriodo(Periodo periodo)
        {
            _dbContext.Periodo.Add(periodo);
        }

        public void UpdatePeriodo(Periodo periodo)
        {
            bool isDetached = _dbContext.Entry(periodo).State == EntityState.Detached;
            if (isDetached)
                _dbContext.Periodo.Attach(periodo);

            _dbContext.Periodo.Update(periodo);
        }

        public async Task<List<Periodo>> GetAllPeriodosTurmaAsync(int IDTurma)
        {
            return await _dbContext.Periodo.Where(x => x.IDTurma.Equals(IDTurma)).ToListAsync();
        }

        public async Task<Periodo> GetPeriodoAsync(int IDPeriodo)
        {
            return await _dbContext.Periodo.Where(x => x.IDPeriodo.Equals(IDPeriodo)).FirstOrDefaultAsync();
        }

        public async Task<Periodo> GetUltimoPeriodoAsync(int IDTurma)
        {
            return await _dbContext.Periodo.Where(x => x.IDTurma.Equals(IDTurma)).OrderByDescending(x => x.DHInicio).FirstOrDefaultAsync();
        }
    }
}
