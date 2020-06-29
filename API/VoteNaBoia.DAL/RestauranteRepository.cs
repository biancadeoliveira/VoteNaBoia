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
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly VoteNaBoiaDbContext _dbContext;
        public RestauranteRepository(VoteNaBoiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => _dbContext;

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        public void CreateRestauranteAsync(Restaurante restaurante)
        {

            _dbContext.Restaurante.Add(restaurante);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR OS DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="idRestaurante">ID DO RESTAURANTE</param>
        /// <returns>OBJETO Restaurante</returns>
        public async Task<Restaurante> GetRestauranteByIDAsync(int idRestaurante)
        {
            return await _dbContext.Restaurante
                //.Include(x=> x.Turma)
              //  .Include(x=> x.FormaPagamento)
                .Where(x => x.IDRestaurante.Equals(idRestaurante))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR UMA LISTA COM OS DADOS DO(S) RESTAURANTE
        /// </summary>
        /// <param name="nome">NOME DO RESTAURANTE</param>
        /// <returns>List de Objetos Restaurante</returns>
        public async Task<List<Restaurante>> GetRestauranteByNameAsync(string nome, int idTurma)
        {
            return await _dbContext.Restaurante.Where(x => x.NMNome.Contains(nome) && x.IDTurma.Equals(idTurma)).ToListAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR UMA LISTA COM OS DADOS DE TODOS OS RESTAURANTE
        /// </summary>
        /// <returns>List de Objetos Restaurante</returns>
        public async Task<List<Restaurante>> GetAllRestauranteAsync(int idTurma)
        {
            return await _dbContext.Restaurante.Where(x=> x.IDTurma.Equals(idTurma)).ToListAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O OBJETO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        public void UpdateRestauranteAsync(Restaurante restaurante)
        {
            //VERIFICA SE O OBJETO ESTÁ ATACHADO
            bool isDetached = _dbContext.Entry(restaurante).State == EntityState.Detached;
            if (isDetached)
                _dbContext.Restaurante.Attach(restaurante);

            _dbContext.Restaurante.Update(restaurante);
        }

        public async Task<Restaurante> GetSeRestauranteJaCadastrado(string nome, string endereco, int idTurma)
        {
            return await _dbContext.Restaurante.Where(x=> x.NMNome.Contains(nome) && x.Endereco.Contains(endereco) && x.IDTurma.Equals(idTurma)).FirstOrDefaultAsync();
        }
    }
}
