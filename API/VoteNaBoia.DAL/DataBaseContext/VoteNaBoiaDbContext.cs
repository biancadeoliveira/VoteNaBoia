using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.DataBaseContext
{
    public class VoteNaBoiaDbContext:DbContext, IUnitOfWork
    {
        private IConfiguration configuration;

        public VoteNaBoiaDbContext(IConfiguration config) 
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = configuration.GetConnectionString("VoteNaBoiaDbBase");
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        public DbSet<CadRestaurante> CadRestaurante { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<TurmaAluno> TurmaAluno { get; set; }
    }
}
