using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class PeriodoResultadoBLL : IPeriodoResultadoBLL
    {
        private readonly IPeriodoResultadoRepository _periodoResultadoRepository;
        private readonly IPeriodoBLL _periodoBLL; 
        
        public PeriodoResultadoBLL(IPeriodoResultadoRepository periodoRepository, IPeriodoBLL periodoBLL)
        {
            _periodoResultadoRepository = periodoRepository;
            _periodoBLL = periodoBLL;
        }
        
        public void Dispose()
        {
            _periodoResultadoRepository?.Dispose();
            _periodoBLL?.Dispose();
        }

        public async Task CreatePeriodoResultado(int IDPeriodo, int IDRestaurante, int NOVotos)
        {
            var msg = "";

            if (!(this.ExistsPeriodoResultado(0, IDRestaurante, IDPeriodo)))
            {
                if(await _periodoBLL.IsPeriodoAbertoAsync(IDPeriodo))
                {
                    var resultado = new PeriodoResultado();

                    resultado.IDPeriodo = IDPeriodo;
                    resultado.IDRestaurante = IDRestaurante;
                    resultado.NOVotos = NOVotos;
                    resultado.SNVisitado = 'N';
                    resultado.DTVisita = DateTime.Parse("3000-12-31");

                    _periodoResultadoRepository.CreatePeriodoResultado(resultado);
                    await _periodoResultadoRepository.UnitOfWork.Commit();

                    return;
                }
                
                msg = "O período informado não está aberto";
                throw new Exception(msg);

            }
            
            msg = "O restaurante já foi computado para o período informado";
            throw new Exception(msg);
        }

        public async Task UpdateSNVisitado(int IDPeriodoResultado)
        {
            var msg = "";
            var periodoResultado = await _periodoResultadoRepository.GetPeriodoResultadoAsync(IDPeriodoResultado);

            if (periodoResultado != null)
            {
                if (!(await _periodoBLL.IsPeriodoAbertoAsync(periodoResultado.IDPeriodo)))
                {
                    msg = "O periodo não está aberto, e não pode ser alterado";
                    throw new Exception(msg);
                }

                periodoResultado.SNVisitado = 'S';
                periodoResultado.DTVisita = DateTime.Today;

                _periodoResultadoRepository.UpdatePeriodoResultado(periodoResultado);
                await _periodoResultadoRepository.UnitOfWork.Commit();
                return;
            }

            msg = "O periodo resultado informado não foi encontrado";
            throw new Exception(msg);
        }

        public async Task<List<PeriodoResultado>> GetAllRestaurantesNVisitadosAsync(int IDPeriodo)
        {
            return await _periodoResultadoRepository.GetAllRestaurantesNVisitadosAsync(IDPeriodo);
        }

        public async Task<List<PeriodoResultado>> GetAllRestaurantesPeriodoAsync(int IDPeriodo)
        {
            return await _periodoResultadoRepository.GetAllRestaurantesPeriodoAsync(IDPeriodo);
        }

        public async Task<List<PeriodoResultado>> GetAllRestaurantesVisitadosAsync(int IDPeriodo)
        {
            return await _periodoResultadoRepository.GetAllRestaurantesVisitadosAsync(IDPeriodo);
        }

        public bool IsRestaurantePeriodoVisitado(int IDPeriodoResultado, int IDRestaurante, int IDPeriodo)
        {
            var periodoResultado = this.GetPeriodo(IDPeriodoResultado, IDRestaurante, IDPeriodo).Result;

            if (periodoResultado != null)
            {
                var msg = "Não foi possível validar se o restaurante já esta visitado no período informado";
                throw new Exception(msg);
            }

            if (periodoResultado.SNVisitado.Equals('S'))
            {
                return true;
            }
            return false;
        }

        public bool ExistsPeriodoResultado(int IDPeriodoResultado, int IDRestaurante = 0, int IDPeriodo = 0)
        {
            var periodoResultado = this.GetPeriodo(IDPeriodoResultado, IDRestaurante, IDPeriodo).Result;

            if (periodoResultado != null)
            {
                return true;
            }
            return false;
        }

        public async Task<PeriodoResultado> GetPeriodo(int IDPeriodoResultado, int IDRestaurante = 0, int IDPeriodo = 0)
        {
            if (IDPeriodoResultado != 0)
            {
                return await _periodoResultadoRepository.GetPeriodoResultadoAsync(IDPeriodoResultado);
            }
            else
            {
                return await _periodoResultadoRepository.GetPeriodoResultadoAsync(IDRestaurante, IDPeriodo);
            }
        }
    }
}
