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
        private readonly ITurmaConfiguracaoBLL _turmaConfiguracaoBLL;
        public PeriodoDiarioBLL(IPeriodoDiarioRepository periodoDiarioRepository, IPeriodoBLL periodoBLL, ITurmaConfiguracaoBLL turmaConfiguracaoBLL)
        {
            _periodoDiarioRepository = periodoDiarioRepository;
            _periodoBLL = periodoBLL;
            _turmaConfiguracaoBLL = turmaConfiguracaoBLL;
        }

        public void Dispose()
        {
            _periodoDiarioRepository?.Dispose();
        }

        public async Task AbrirPeriodoDiario(int IDPeriodo)
        {
            var msg = "";
            DateTime dhInsert = DateTime.Now;
            DateTime dhInicioDefault = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,7,0,0);// data inicio é o dia(hoje) 7:00
            DateTime dhFimDefault = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 30, 59);// data fim é o dia(hoje) 11:00
            var periodo = await _periodoBLL.GetPeriodoAsync(IDPeriodo);


            if (await _periodoBLL.IsPeriodoAbertoAsync(IDPeriodo)) 
            {
                var periodoDiarioAtual = await this.GetUltimoPeriodoDiarioAsync(IDPeriodo);
                if(await this.IsPeriodoAbertoAsync(periodoDiarioAtual.IDPeriodoDiario)) //teste se periodo diário atual está aberto
                {
                 
                    // testa se dhInsert é maior que o início e menor que o fim
                    if (dhInsert.CompareTo(dhInicioDefault) ==1 && dhInsert.CompareTo(dhFimDefault) ==-1)
                    {
                        //não faz nada, está dentro do período - não precisa abrir nem fechar
                    }
                    else
                    {
                        this.FecharPeriodoDiario(periodoDiarioAtual); //fecha o período atual
                        //se a data de inicio do periodo atual for menor que a data de inserção, aí abre novo período, senão, indica que é o mesmo dia, não pode abrir votação
                        if (periodoDiarioAtual.DHInicio.Date.CompareTo(dhInsert.Date) == -1)
                        {
                            /* var dhFimNovoPeriodoDiario = new DateTime();*/
                            var periodoDiario = new PeriodoDiario(IDPeriodoDiario: 0, IDPeriodo: IDPeriodo, DHInicio: DateTime.Today, DHFim: DateTime.Today, 'S');

                            _periodoDiarioRepository.AbrirPeriodo(periodoDiario);
                            await _periodoDiarioRepository.UnitOfWork.Commit();
                        }
                        else
                        {
                            msg = "Ainda não pode ser aberto um novo período para votação";
                            throw new Exception(msg);
                        }
                    }
                }
                else
                {
                    //se a data de inicio do periodo atual for menor que a data de inserção, aí fecha o período e abre, senão, indica que é o mesmo dia, não pode abrir votação
                    if (periodoDiarioAtual.DHInicio.CompareTo(dhInsert) == -1 && dhInsert.CompareTo(dhInicioDefault) == 1 && dhInsert.CompareTo(dhFimDefault) == -1)
                    {
                        var periodoDiario = new PeriodoDiario(IDPeriodoDiario: 0, IDPeriodo: IDPeriodo, DHInicio: DateTime.Today, DHFim: DateTime.Today, 'S');

                        _periodoDiarioRepository.AbrirPeriodo(periodoDiario);
                        await _periodoDiarioRepository.UnitOfWork.Commit();
                    }
                    else
                    {
                        msg = "Ainda não pode ser aberto um novo período para votação";
                        throw new Exception(msg);
                    }
                }
            }

           
        }

        public  void FecharPeriodoDiario(PeriodoDiario periodoDiario)
        {
            periodoDiario.DHFim = DateTime.Now;
            periodoDiario.SNAtivo = 'N';
            _periodoDiarioRepository.FecharPeriodo(periodoDiario);
             
        }


        public async Task<PeriodoDiario> GetUltimoPeriodoDiarioAsync(int IDPeriodo)
        {
            return await _periodoDiarioRepository.GetUltimoPeriodoAsync(IDPeriodo);
        }

        public async Task<bool> IsPeriodoAbertoAsync(int IDPeriodoDiario)
        {
            return await _periodoDiarioRepository.IsPeriodoAbertoAsync(IDPeriodoDiario);
        }
    }
}
