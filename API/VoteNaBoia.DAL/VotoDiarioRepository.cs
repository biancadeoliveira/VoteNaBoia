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
    public class VotoDiarioRepository : IVotoDiarioRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;
        public VotoDiarioRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<List<VotoDiario>> GetResultadoVotoDiarioAsync(DateTime DHInclusao)
        {
            return null;
            //return await _dbContext.VotoDiario.Count(x=> x.IDPeriodoResultado).Where(x=> x.DHInclusao>=DHInclusao).Grou();
        }


        public void InsertVotoDiarioAsync(VotoDiario votoDiario)
        {
            _dbContext.VotoDiario.Add(votoDiario);
        }
    }
}
