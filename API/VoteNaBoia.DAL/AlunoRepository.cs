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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;
        public AlunoRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => _dbContext;

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="aluno">OBJETO ALUNO</param>
        public void CreateAlunoAsync(Aluno aluno)
        {
            _dbContext.Aluno.Add(aluno);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR OS DADOS DO ALUNO
        /// </summary>
        /// <param name="IDAluno">ID DO ALUNO</param>
        /// <returns>OBJETO Aluno</returns>
        public async Task<Aluno> GetAlunoAsync(int IDAluno)
        {
            return await _dbContext.Aluno.Where(x => x.IDAluno.Equals(IDAluno)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR TODOS OS ALUNOS
        /// </summary>
        /// <param name="IDAluno">ID DO ALUNO</param>
        /// <returns>OBJETO Aluno</returns>
        public async Task<List<Aluno>> GetAllAlunoAsync()
        {
            return await _dbContext.Aluno.ToListAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O OBJETO ALUNO
        /// </summary>
        /// <param name="aluno">OBJETO ALUNO</param>
        public void UpdateAlunoAsync(Aluno aluno)
        {
            //VERIFICA SE O OBJETO ESTÁ ATACHADO
            bool isDetached = _dbContext.Entry(aluno).State == EntityState.Detached;
            if (isDetached)
                _dbContext.Aluno.Attach(aluno);

            _dbContext.Aluno.Update(aluno);
        }
    }
}
