using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IRestauranteRepository:IRepository
    {
        Task<Restaurante> GetRestauranteByIDAsync(int idRestaurante);
        Task<List<Restaurante>> GetRestauranteByNameAsync(string nome);
        Task<List<Restaurante>> GetAllRestauranteAsync();
        void CreateRestauranteAsync(Restaurante restaurante);
        void UpdateRestauranteAsync(Restaurante restaurante);
    }
}
