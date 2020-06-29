using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class VotoDiarioBLL : IVotoDiarioBLL
    {
        private readonly IVotoDiarioRepository _votoDiarioRepository;
        private readonly IRestauranteBLL _restauranteBLL;
        private readonly IPeriodoResultadoBLL _periodoResultadoBLL;
        private readonly IPeriodoBLL _periodoBLL;
        private readonly IPeriodoDiarioBLL _periodoDiarioBLL;

        public VotoDiarioBLL(IVotoDiarioRepository votoDiarioRepository, IRestauranteBLL restauranteBLL, IPeriodoResultadoBLL periodoResultadoBLL, IPeriodoBLL periodoBLL, IPeriodoDiarioBLL periodoDiarioBLL)
        {
            _votoDiarioRepository = votoDiarioRepository;
            _restauranteBLL = restauranteBLL;
            _periodoResultadoBLL = periodoResultadoBLL;
            _periodoBLL = periodoBLL;
            _periodoDiarioBLL = periodoDiarioBLL;
        }
        public void Dispose()
        {
            _votoDiarioRepository?.Dispose();
        }

        public async Task<Restaurante> GetVotoDiarioAsync(int IDTurmaAluno,DateTime DHInclusao)
        {
            var idPeriodoResultado =  await _votoDiarioRepository.GetResultadoVotoDiarioAsync(IDTurmaAluno,DHInclusao);
            var periodoResultado = await _periodoResultadoBLL.GetPeriodo(idPeriodoResultado);

            return await _restauranteBLL.GetRestauranteByIdAsync(periodoResultado.IDRestaurante); // restaurante
        }

        public async Task InsertVotoDiarioAsync(VotoDiario votoDiario)
        {
            var periodoResultado = await _periodoResultadoBLL.GetPeriodo(votoDiario.IDPeriodoResultado);
            var periodoDiario = await _periodoDiarioBLL.GetUltimoPeriodoAsync(periodoResultado.IDPeriodo);
            if (await _periodoDiarioBLL.IsPeriodoAbertoAsync(periodoDiario.IDPeriodoDiario)) 
            {
                _votoDiarioRepository.InsertVotoDiarioAsync(votoDiario);
                await _votoDiarioRepository.UnitOfWork.Commit();
            }
            else
            {
                var msg = "Não existe período aberto para votação";
                throw new Exception(msg);
            }
            
        }

        public async Task<List<Restaurante>> GetVotoDiarioRestaurantesAsync(int idTurma)
        {
            List<Restaurante> restaurantes;
            restaurantes = new List<Restaurante>();
            var periodo = await _periodoBLL.GetUltimoPeriodoAsync(idTurma);//pega o último período da turma iniformada
            if (await _periodoBLL.IsPeriodoAbertoAsync(periodo.IDPeriodo)) {// testa se o último período está aberto
                var resultados = await _periodoResultadoBLL.GetAllRestaurantesNVisitadosAsync(periodo.IDPeriodo);//pega os restaurantes não visitados
                foreach(var resultado in resultados) //percorre cada resultado para pegar os dados do restaurante
                { //adiciona o restaurante numa lista
                    restaurantes.Add(await _restauranteBLL.GetRestauranteByIdAsync(resultado.IDRestaurante));
                }
            }
            else
            {
                var msg = "Não existe período aberto para votação";
                throw new Exception(msg);
            }
            return restaurantes; // retorna a lista de restaurantes
        }
    }
}
