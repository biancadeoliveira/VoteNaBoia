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
    public class LoginRepository : ILoginRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;

        public LoginRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<Aluno> GetAlunoLoginAsync(string email, string senha)
        {
            return await _dbContext.Aluno.Where(x => x.Email.Equals(email) && x.Senha.Equals(senha)).FirstOrDefaultAsync();
        }
    }
}
