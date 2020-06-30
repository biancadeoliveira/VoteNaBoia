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
    public class TurmaConfiguracaoRepository : ITurmaConfiguracaoRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public TurmaConfiguracaoRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void CreateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao)
        {
            _dbContext.TurmaConfiguracao.Add(turmaConfiguracao);
        }

        public async Task<TurmaConfiguracao> GetTurmaConfiguracaoAsync(int IDTurma)
        {
            return await _dbContext.TurmaConfiguracao.Where(x => x.IDTurma.Equals(IDTurma)).FirstOrDefaultAsync();
        }

        public void UpdateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao)
        {
            bool isDetached = _dbContext.Entry(turmaConfiguracao).State == EntityState.Detached;
            if (isDetached)
                _dbContext.TurmaConfiguracao.Attach(turmaConfiguracao);

            _dbContext.TurmaConfiguracao.Update(turmaConfiguracao);
        }
    }
}
