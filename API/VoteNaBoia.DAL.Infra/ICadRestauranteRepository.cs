using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface ICadRestauranteRepository:IRepository
    {
        Task<CadRestaurante> GetCadRestauranteAsync(int restId);
        void CreateCadRestauranteAsync(CadRestaurante restaurante);
        void UpdateCadRestauranteAsync(CadRestaurante restaurante);
    }
}
