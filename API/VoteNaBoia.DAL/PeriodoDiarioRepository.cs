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
    public class PeriodoDiarioRepository : IPeriodoDiarioRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public PeriodoDiarioRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void AbrirPeriodo(PeriodoDiario periodoDiario)
        {
            _dbContext.PeriodoDiario.Add(periodoDiario);
        }

        public void FecharPeriodo(PeriodoDiario periodoDiario)
        {
            bool isDetached = _dbContext.Entry(periodoDiario).State == EntityState.Detached;
            if (isDetached)
                _dbContext.PeriodoDiario.Attach(periodoDiario);

            _dbContext.PeriodoDiario.Update(periodoDiario);
        }

        public async Task<List<PeriodoDiario>> GetAllPeriodosAsync(int IDPeriodo)
        {
            return await _dbContext.PeriodoDiario.Where(x => x.IDPeriodo.Equals(IDPeriodo)).ToListAsync();
        }

        public async Task<PeriodoDiario> GetPeriodoAsync(int IDPeriodo)
        {
            return await _dbContext.PeriodoDiario.Where(x => x.IDPeriodoDiario.Equals(IDPeriodo)).FirstOrDefaultAsync();
        }

        public async Task<PeriodoDiario> GetUltimoPeriodoAsync(int IDPeriodo)
        {
            return await _dbContext.PeriodoDiario.Where(x => x.IDPeriodo.Equals(IDPeriodo)).OrderByDescending(x => x.DHInicio).FirstOrDefaultAsync();
        }

        public async Task<bool> IsPeriodoAbertoAsync(int IDPeriodoDiario)
        {
            var periodoDiario = await _dbContext.PeriodoDiario.Where(x => x.IDPeriodoDiario.Equals(IDPeriodoDiario)).FirstOrDefaultAsync();
            
            if(periodoDiario.SNAtivo.Equals('S'))
            {
                return true;
            }
            return false;
        }
    }
}
