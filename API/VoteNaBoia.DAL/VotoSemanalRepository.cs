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
    public class VotoSemanalRepository : IVotoSemanalRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public VotoSemanalRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public void AddVotoSemanal(VotoSemanal votoSemanal)
        {
            _dbContext.VotoSemanal.Add(votoSemanal);
        }

        public async Task<List<VotoSemanal>> GetAllVotosPeriodoAsync(int IDPeriodo)
        {
            return await _dbContext.VotoSemanal.Where(x => x.IDPeriodo.Equals(IDPeriodo)).ToListAsync();
        }

        public async Task<VotoSemanal> GetVotoSemanal(int IDVotoSemanal)
        {
            return await _dbContext.VotoSemanal.Where(x => x.IDVotoSemanal.Equals(IDVotoSemanal)).FirstOrDefaultAsync();
        }

        public async Task<VotoSemanal> GetVotoSemanal(int IDPeriodo, int IDTurmaAluno)
        {
            return await _dbContext.VotoSemanal.Where(x => x.IDPeriodo.Equals(IDPeriodo) && x.IDTurmaAluno.Equals(IDTurmaAluno)).FirstOrDefaultAsync();
        }
    }
}
