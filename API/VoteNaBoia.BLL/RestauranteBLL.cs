using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class RestauranteBLL:IRestauranteBLL
    {
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IPagamentoRestauranteBLL _pagamentoRestauranteBLL;
        
        public RestauranteBLL(IRestauranteRepository restauranteRepository, IPagamentoRestauranteBLL pagamentoRestauranteBLL) 
        {
            _restauranteRepository = restauranteRepository;
            _pagamentoRestauranteBLL = pagamentoRestauranteBLL;
        }


        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        /// <returns></returns>
        public async Task CreateRestauranteAsync(Restaurante restaurante)
        {
           // var cRestaurante = await _restauranteRepository.GetSeRestauranteJaCadastrado(restaurante.NMNome, restaurante.Endereco, restaurante.IDTurma);
            if (await isRestauranteJaCadastrado(restaurante.NMNome, restaurante.Endereco, restaurante.IDTurma))
            {
                var msg = "Restaurante já cadastrado!!";
                throw new Exception(msg);
            }
            else
            {
                _restauranteRepository.CreateRestauranteAsync(restaurante);
                await _restauranteRepository.UnitOfWork.Commit();
            }
            
        }

        public void Dispose()
        {
            _restauranteRepository?.Dispose();
        }

        public async Task<Restaurante> GetRestauranteByIdAsync(int idRestaurante)
        {
            return await _restauranteRepository.GetRestauranteByIDAsync(idRestaurante);
        }

        public async Task<List<Restaurante>> GetRestauranteByNameAsync(string nome, int idTurma)
        {
            new List<Restaurante>();

            return await _restauranteRepository.GetRestauranteByNameAsync(nome, idTurma);
        }

        public async Task<List<Restaurante>> GetAllRestauranteAsync(int idTurma)
        {
            new List<Restaurante>();

            return await _restauranteRepository.GetAllRestauranteAsync(idTurma);
        }

        public async Task<List<Restaurante>> GetRestaurantesInativosAsync(int idTurma)
        {
            new List<Restaurante>();

            return await _restauranteRepository.GetAllRestaurantesInativosAsync(idTurma);
        }

        public async Task UpdateRestauranteAsync(Restaurante restaurante)
        {
            _restauranteRepository.UpdateRestauranteAsync(restaurante);
            await _restauranteRepository.UnitOfWork.Commit();
        }


        public async Task<string> UpdateStatusRestauranteAsync(int idRestaurante, char status)
        {
            if (!(status.Equals('S')) && !(status.Equals('N')))
            {
                return "O status deve ser S ou N";
            }
            var restaurante = await GetRestauranteByIdAsync(idRestaurante);
            // setar novo status
            restaurante.SNAtivo=status;
            _restauranteRepository.UpdateRestauranteAsync(restaurante);
            await _restauranteRepository.UnitOfWork.Commit();

            return "";

        }

        public async Task<bool> isRestauranteAtivo(int idRestaurante) {
            var restaurante = await _restauranteRepository.GetRestauranteByIDAsync(idRestaurante);
            if(restaurante.SNAtivo.Equals('S'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> isRestauranteJaCadastrado(string nome, string endereco, int idTurma)
        {
            var cRestaurante = await _restauranteRepository.GetSeRestauranteJaCadastrado(nome, endereco, idTurma);
            if (cRestaurante != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> isRestauranteJaCadastradoById(int idRestaurante, int idTurma)
        {
            var cRestaurante = await _restauranteRepository.GetRestauranteByIDAsync(idRestaurante);
            if (cRestaurante != null && cRestaurante.IDTurma.Equals(idTurma))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
