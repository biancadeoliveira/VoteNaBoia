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

 
        public void  CreateRestauranteAsync(Restaurante restaurante)
        {

             _dbContext.Restaurante.Add(restaurante);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }


        public async Task<Restaurante> GetRestauranteByIDAsync(int idRestaurante)
        {
            return await _dbContext.Restaurante
                .Include(x=> x.PagamentoRestaurante).ThenInclude(p=> p.FormaPagamento)
                .Include(x => x.Turma)
                .Where(x => x.IDRestaurante.Equals(idRestaurante))
                .FirstOrDefaultAsync();
        }


        public async Task<List<Restaurante>> GetRestauranteByNameAsync(string nome, int idTurma)
        {
            return await _dbContext.Restaurante
                .Include(x => x.PagamentoRestaurante).ThenInclude(p => p.FormaPagamento)
                //.Include(x => x.Turma)
                .Where(x => x.NMNome.Contains(nome) && x.IDTurma.Equals(idTurma)).ToListAsync();
        }

        public async Task<List<Restaurante>> GetAllRestauranteAsync(int idTurma)
        {
            return await _dbContext.Restaurante
                .Include(x => x.PagamentoRestaurante).ThenInclude(p => p.FormaPagamento)
               // .Include(x => x.Turma)
                .Where(x=> x.IDTurma.Equals(idTurma)).ToListAsync();
        }

        public async Task<List<Restaurante>> GetAllRestaurantesInativosAsync(int idTurma)
        {
            return await _dbContext.Restaurante
                .Include(x => x.PagamentoRestaurante).ThenInclude(p => p.FormaPagamento)
                .Where(x => x.IDTurma.Equals(idTurma) && x.SNAtivo.Equals('N')).ToListAsync();
        }
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
