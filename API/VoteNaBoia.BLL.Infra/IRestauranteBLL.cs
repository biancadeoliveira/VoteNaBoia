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
        Task<List<Restaurante>> GetRestauranteByNameAsync(string nome, int idTurma);
        Task<List<Restaurante>> GetAllRestauranteAsync(int idTurma);
        Task<List<Restaurante>> GetRestaurantesInativosAsync(int idTurma);
        Task<bool> isRestauranteAtivo(int idRestaurante);
        Task<bool> isRestauranteJaCadastrado(string nome, string endereco, int idTurma);
        Task<bool> isRestauranteJaCadastradoById(int idRestaurante, int idTurma);
        Task CreateRestauranteAsync(Restaurante restaurante);
        Task UpdateRestauranteAsync(Restaurante restaurante);
        Task<string> UpdateStatusRestauranteAsync(int idRestaurante, char status);
    }
}
