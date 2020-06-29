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

        public async Task<int> GetResultadoVotoDiarioAsync(int IDTurmaAluno,DateTime DHInclusao)
        {

            var votos = _dbContext.VotoDiario
            .Where(x => x.DHInclusao >= DHInclusao && x.IDTurmaAluno.Equals(IDTurmaAluno));
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
    }
}
