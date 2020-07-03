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
        private readonly IPeriodoBLL _periodoBLL;
        public PeriodoDiarioBLL(IPeriodoDiarioRepository periodoDiarioRepository, IPeriodoBLL periodoBLL)
        {
            _periodoDiarioRepository = periodoDiarioRepository;
            _periodoBLL = periodoBLL;
        }

        public void Dispose()
        {
            _periodoDiarioRepository?.Dispose();
        }

        public async Task AbrirPeriodo(int IDPeriodo)
        {
            //  await this.FecharPeriodo(IDPeriodo);

          //  var msg = "";
            var dhInsert = DateTime.Now;

            if (await _periodoBLL.IsPeriodoAbertoAsync(IDPeriodo)) 
            {
                var periodoDiarioAtual = await this.GetUltimoPeriodoAsync(IDPeriodo);
                if(await this.IsPeriodoAbertoAsync(periodoDiarioAtual.IDPeriodoDiario)) //teste se periodo diário atual está aberto
                {
                    // testa se dhInsert é maior que o início e menor que o fim
                    if (dhInsert.CompareTo(periodoDiarioAtual.DHInicio)==1 && dhInsert.CompareTo(periodoDiarioAtual.DHFim)==-1)
                    {
                        // msg = "Período não "
                    }
                    else
                    {
                        await this.FecharPeriodo(periodoDiarioAtual.IDPeriodoDiario); //fecha periíodo e abre um novo
                        var dhFim = new DateTime();
                        var periodoDiario = new PeriodoDiario(IDPeriodoDiario: 0, IDPeriodo: IDPeriodo, DHInicio: DateTime.Today, DHFim: dhFim.AddDays(1), 'S');

                        _periodoDiarioRepository.AbrirPeriodo(periodoDiario);
                        await _periodoDiarioRepository.UnitOfWork.Commit();
                    }
                }
                else
                {
                    var dhFim = new DateTime();
                    var periodoDiario = new PeriodoDiario(IDPeriodoDiario: 0, IDPeriodo: IDPeriodo, DHInicio: DateTime.Today, DHFim: dhFim.AddDays(1), 'S');

                    _periodoDiarioRepository.AbrirPeriodo(periodoDiario);
                    await _periodoDiarioRepository.UnitOfWork.Commit();
                }
            }

           
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


        public async Task<PeriodoDiario> GetUltimoPeriodoAsync(int IDPeriodo)
        {
            return await _periodoDiarioRepository.GetUltimoPeriodoAsync(IDPeriodo);
        }

        public async Task<bool> IsPeriodoAbertoAsync(int IDPeriodoDiario)
        {
            return await _periodoDiarioRepository.IsPeriodoAbertoAsync(IDPeriodoDiario);
        }
    }
}
