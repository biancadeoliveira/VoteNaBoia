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

        public int GetResultadoVotoDiarioAsync( int idPeriodoDiario)
        {

            var votos = _dbContext.VotoDiario
            .Where(x => x.IDPeriodoDiario.Equals(idPeriodoDiario));
            foreach(var i in votos.GroupBy(v=> v.IDPeriodoResultado).Select(group=> new { 
                periodo = group.Key,
                total = group.Count()
            })
            .OrderByDescending(x=> x.total))
            {
                return  i.periodo;
            }
            
            return  1;
            
        }


        public void InsertVotoDiarioAsync(VotoDiario votoDiario)
        {
            _dbContext.VotoDiario.Add(votoDiario);
        }

        public async Task<VotoDiario> GetVotoDiarioAsync(int idPeriodoDiario, int idTurmaAluno)
        {
            return await _dbContext.VotoDiario.Where(x => x.IDPeriodoDiario.Equals(idPeriodoDiario) && x.IDTurmaAluno.Equals(idTurmaAluno)).FirstOrDefaultAsync();
        }
    }
}
