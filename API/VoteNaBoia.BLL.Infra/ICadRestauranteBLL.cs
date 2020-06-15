using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface ICadRestauranteBLL:IDisposable
    {
        Task<CadRestaurante> GetCadRestauranteAsync(int restId);
        Task CreateCadRestauranteAsync(CadRestaurante restaurante);
        Task UpdateCadRestauranteAsync(CadRestaurante restaurante);
    }
}
