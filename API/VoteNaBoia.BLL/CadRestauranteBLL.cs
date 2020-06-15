using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class CadRestauranteBLL:ICadRestauranteBLL
    {
        private readonly ICadRestauranteRepository _cadRestauranteRepository;
        public CadRestauranteBLL(ICadRestauranteRepository cadRestauranteRepository) 
        {
            _cadRestauranteRepository = cadRestauranteRepository;
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        /// <returns></returns>
        public async Task CreateCadRestauranteAsync(CadRestaurante restaurante)
        {
            _cadRestauranteRepository.CreateCadRestauranteAsync(restaurante);
            await _cadRestauranteRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _cadRestauranteRepository?.Dispose();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restId">ID DO RESTAURANTE</param>
        /// <returns>OBJETO RESTAURANTE</returns>
        public async Task<CadRestaurante> GetCadRestauranteAsync(int restId)
        {
            //VERIFICAR SE OS DADOS QUE SERÃO CONSTRUÍDOS ESTÃO OK
            new CadRestaurante( 0,"","",0,"","","","","");

            return await _cadRestauranteRepository.GetCadRestauranteAsync(restId);
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O CADASTRO DO RESTAURANTE
        /// </summary>
        /// <param name="restaurante">OBJETO RESTAURANTE</param>
        /// <returns></returns>
        public async Task UpdateCadRestauranteAsync(CadRestaurante restaurante)
        {
            _cadRestauranteRepository.UpdateCadRestauranteAsync(restaurante);
            await _cadRestauranteRepository.UnitOfWork.Commit();
        }
    }
}
