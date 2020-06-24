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
        
        public RestauranteBLL(IRestauranteRepository restauranteRepository) 
        {
            _restauranteRepository = restauranteRepository;
        }


        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        /// <returns></returns>
        public async Task CreateRestauranteAsync(Restaurante restaurante)
        {
            
            // valida se a turma existe
          //  if (_turmaRepository.GetTurmaByIDAsync(restaurante.IDTurma) != null) {
                _restauranteRepository.CreateRestauranteAsync(restaurante);
                await _restauranteRepository.UnitOfWork.Commit();
            
        }

        public void Dispose()
        {
            _restauranteRepository?.Dispose();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="idRestaurante">ID DO RESTAURANTE</param>
        /// <returns>OBJETO RESTAURANTE</returns>
        public async Task<Restaurante> GetRestauranteByIdAsync(int idRestaurante)
        {
            //VERIFICAR SE OS DADOS QUE SERÃO CONSTRUÍDOS ESTÃO OK
            new Restaurante( 0,"","",0,"","","","",' ');

            return await _restauranteRepository.GetRestauranteByIDAsync(idRestaurante);
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR UMA LISTA DE RESTAURANTES
        /// </summary>
        /// <param name="nome">NOME DO RESTAURANTE</param>
        /// <returns>LISTA DE RESTAURANTES</returns>
        public async Task<List<Restaurante>> GetRestauranteByNameAsync(string nome)
        {
            new List<Restaurante>();

            return await _restauranteRepository.GetRestauranteByNameAsync(nome);
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR UMA LISTA DE RESTAURANTES
        /// </summary>
        /// <param name="nome">NOME DO RESTAURANTE</param>
        /// <returns>LISTA DE RESTAURANTES</returns>
        public async Task<List<Restaurante>> GetAllRestauranteAsync()
        {
            new List<Restaurante>();

            return await _restauranteRepository.GetAllRestauranteAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        /// <returns></returns>
        public async Task UpdateRestauranteAsync(Restaurante restaurante)
        {
            _restauranteRepository.UpdateRestauranteAsync(restaurante);
            await _restauranteRepository.UnitOfWork.Commit();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O STATUS DO RESTAURANTE
        /// </summary>
        /// <param name="idRestaurante">ID DO RESTAURANTE</param>
        /// <param name="status">STATUS</param>
        /// <returns>OK</returns>
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
    }
}
