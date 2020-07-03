using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class PagamentoRestauranteBLL : IPagamentoRestauranteBLL
    {
        private readonly IPagamentoRestauranteRepository _pagamentoRestauranteRepository;
        public PagamentoRestauranteBLL(IPagamentoRestauranteRepository pagamentoRestauranteRepository)
        {
            _pagamentoRestauranteRepository = pagamentoRestauranteRepository;
        }

        public async Task CreatePagamentoRestauranteAsync(PagamentoRestaurante pagamentoRestaurante)
        {
            _pagamentoRestauranteRepository.CreatePagamentoRestauranteAsync(pagamentoRestaurante);
            await _pagamentoRestauranteRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _pagamentoRestauranteRepository?.Dispose();
        }

        
        
    }
}
