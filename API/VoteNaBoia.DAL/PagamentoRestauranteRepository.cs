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
    public class PagamentoRestauranteRepository : IPagamentoRestauranteRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public PagamentoRestauranteRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void CreatePagamentoRestauranteAsync(PagamentoRestaurante pagamentoRestaurante)
        {
            _dbContext.PagamentoRestaurante.Add(pagamentoRestaurante);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        
    }
}
