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
    public class CadRestauranteRepository : ICadRestauranteRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;
        public CadRestauranteRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => _dbContext;

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        public void CreateCadRestauranteAsync(CadRestaurante restaurante)
        {
            _dbContext.CadRestaurante.Add(restaurante);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR OS DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="restId">ID DO RESTAURANTE</param>
        /// <returns>OBJETO CadRestaurante</returns>
        public async Task<CadRestaurante> GetCadRestauranteAsync(int restId)
        {
            return await _dbContext.CadRestaurante.Where(x => x.RestId.Equals(restId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O OBJETO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        public void UpdateCadRestauranteAsync(CadRestaurante restaurante)
        {
            //VERIFICA SE O OBJETO ESTÁ ATACHADO
            bool isDetached = _dbContext.Entry(restaurante).State == EntityState.Detached;
            if (isDetached)
                _dbContext.CadRestaurante.Attach(restaurante);

            _dbContext.CadRestaurante.Update(restaurante);
        }
    }
}
