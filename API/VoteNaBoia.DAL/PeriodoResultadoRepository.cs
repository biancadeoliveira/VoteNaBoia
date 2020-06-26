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
    public class PeriodoResultadoRepository : IPeriodoResultadoRepository
    {

        private readonly VoteNaBoiaDbContext _dbContext;

        public PeriodoResultadoRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void CreatePeriodoResultado(PeriodoResultado periodoResultado)
        {
            _dbContext.PeriodoResultado.Add(periodoResultado);
        }

        public void UpdatePeriodoResultado(PeriodoResultado periodoResultado)
        {
            bool isDetached = _dbContext.Entry(periodoResultado).State == EntityState.Detached;
            if (isDetached)
                _dbContext.PeriodoResultado.Attach(periodoResultado);

            _dbContext.PeriodoResultado.Update(periodoResultado);
        }

        public async Task<List<PeriodoResultado>> GetAllRestaurantesNVisitadosAsync(int IDPeriodo)
        {
            return await _dbContext.PeriodoResultado.Where(x => x.IDPeriodo.Equals(IDPeriodo) && x.SNVisitado.Equals('N')).ToListAsync();
        }

        public async Task<List<PeriodoResultado>> GetAllRestaurantesPeriodoAsync(int IDPeriodo)
        {
            return await _dbContext.PeriodoResultado.Where(x => x.IDPeriodo.Equals(IDPeriodo)).ToListAsync();
        }

        public async Task<List<PeriodoResultado>> GetAllRestaurantesVisitadosAsync(int IDPeriodo)
        {
            return await _dbContext.PeriodoResultado.Where(x => x.IDPeriodo.Equals(IDPeriodo) && x.SNVisitado.Equals('S')).ToListAsync();
        }

        public async Task<PeriodoResultado> GetPeriodoResultadoAsync(int IDRestaurante, int IDPeriodo)
        {
            return await _dbContext.PeriodoResultado.Where(x => x.IDRestaurante.Equals(IDRestaurante) && x.IDPeriodo.Equals(IDPeriodo)).FirstOrDefaultAsync();
        }

        public async Task<PeriodoResultado> GetPeriodoResultadoAsync(int IDPeriodoResultado)
        {
            return await _dbContext.PeriodoResultado.Where(x => x.IDPeriodoResultado.Equals(IDPeriodoResultado)).FirstOrDefaultAsync();
        }
    }
}
