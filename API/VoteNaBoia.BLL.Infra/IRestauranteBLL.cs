using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IRestauranteBLL:IDisposable
    {
        Task<Restaurante> GetRestauranteByIdAsync(int idRestaurante);
        Task<List<Restaurante>> GetRestauranteByNameAsync(string nome);
        Task<List<Restaurante>> GetAllRestauranteAsync();
        Task CreateRestauranteAsync(Restaurante restaurante);
        Task UpdateRestauranteAsync(Restaurante restaurante);
        Task<string> UpdateStatusRestauranteAsync(int idRestaurante, char status);
    }
}
