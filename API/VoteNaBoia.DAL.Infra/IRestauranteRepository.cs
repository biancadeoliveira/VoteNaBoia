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
        Task<List<Restaurante>> GetRestauranteByNameAsync(string nome, int idTurma);
        Task<Restaurante> GetSeRestauranteJaCadastrado(string nome, string endereco, int idTurma);
        Task<List<Restaurante>> GetAllRestauranteAsync(int idTurma);
        Task<List<Restaurante>> GetAllRestaurantesInativosAsync(int idTurma);
        void CreateRestauranteAsync(Restaurante restaurante);
        void UpdateRestauranteAsync(Restaurante restaurante);
    }
}
