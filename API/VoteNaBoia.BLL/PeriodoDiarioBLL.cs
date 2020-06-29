using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class PeriodoDiarioBLL : IPeriodoDiarioBLL
    {
        private readonly IPeriodoDiarioRepository _periodoDiarioRepository;
        public PeriodoDiarioBLL(IPeriodoDiarioRepository periodoDiarioRepository)
        {
            _periodoDiarioRepository = periodoDiarioRepository;
        }

        public void Dispose()
        {
            _periodoDiarioRepository?.Dispose();
        }

        public async Task AbrirPeriodo(int IDPeriodo)
        {
            await this.FecharPeriodo(IDPeriodo);    

            var periodoDiario = new PeriodoDiario();

            periodoDiario.IDPeriodoDiario = 0;
            periodoDiario.IDPeriodo = IDPeriodo;
            periodoDiario.DHInicio = DateTime.Now;
            periodoDiario.DHFim = DateTime.Parse("3000-12-01");
            periodoDiario.SNAtivo = 'S';

            _periodoDiarioRepository.AbrirPeriodo(periodoDiario);
            await _periodoDiarioRepository.UnitOfWork.Commit();
        }

        public async Task FecharPeriodo(int IDTurma)
        {
            var periodoAnterior = await _periodoDiarioRepository.GetUltimoPeriodoAsync(IDTurma);

            if (periodoAnterior != null)
            {
                if (_periodoDiarioRepository.IsPeriodoAbertoAsync(periodoAnterior.IDPeriodo).Result)
                {
                    periodoAnterior.DHFim = DateTime.Now;
                    periodoAnterior.SNAtivo = 'N';
                    _periodoDiarioRepository.FecharPeriodo(periodoAnterior);
                }
            }
        }

     /*   public async Task<List<Periodo>> GetAllPeriodosTurmaAsync(int IDTurma)
        {
            return null; // await _periodoDiarioRepository.GetAllPeriodosTurmaAsync(IDTurma);
        }*/

        public async Task<PeriodoDiario> GetUltimoPeriodoAsync(int IDTurma)
        {
            return await _periodoDiarioRepository.GetUltimoPeriodoAsync(IDTurma);
        }

        public async Task<bool> IsPeriodoAbertoAsync(int IDPeriodo)
        {
            return await _periodoDiarioRepository.IsPeriodoAbertoAsync(IDPeriodo);
        }
    }
}
