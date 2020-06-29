using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class PeriodoBLL : IPeriodoBLL
    {
        private readonly IPeriodoRepository _periodoRepository;
        public PeriodoBLL(IPeriodoRepository periodoRepository)
        {
            _periodoRepository = periodoRepository;
        }

        public void Dispose()
        {
            _periodoRepository?.Dispose();
        }

        public async Task AbrirPeriodo(int IDTurma)
        {
            await this.FecharPeriodo(IDTurma);    

            var periodo = new Periodo();
            
            periodo.IDPeriodo = 0;
            periodo.IDTurma = IDTurma;
            periodo.DHInicio = DateTime.Now;
            periodo.DHFim = DateTime.Parse("3000-12-01");
            periodo.SNAtivo = 'S';

            _periodoRepository.AbrirPeriodo(periodo);
            await _periodoRepository.UnitOfWork.Commit();
        }

        public async Task FecharPeriodo(int IDTurma)
        {
            var periodoAnterior = await _periodoRepository.GetUltimoPeriodoAsync(IDTurma);

            if (periodoAnterior != null)
            {
                if (this.IsPeriodoAbertoAsync(periodoAnterior.IDPeriodo).Result)
                {
                    periodoAnterior.DHFim = DateTime.Now;
                    periodoAnterior.SNAtivo = 'N';
                    _periodoRepository.FecharPeriodo(periodoAnterior);
                }
            }
        }

        public async Task<List<Periodo>> GetAllPeriodosTurmaAsync(int IDTurma)
        {
            return await _periodoRepository.GetAllPeriodosTurmaAsync(IDTurma);
        }

        public async Task<Periodo> GetUltimoPeriodoAsync(int IDTurma)
        {
            return await _periodoRepository.GetUltimoPeriodoAsync(IDTurma);
        }

        public async Task<bool> IsPeriodoAbertoAsync(int IDPeriodo)
        {
            var periodo = await _periodoRepository.GetPeriodoAsync(IDPeriodo);

            if(periodo == null)
            {
                var msg = "O período informado não existe";
                throw new Exception(msg);
            }

            if (periodo.SNAtivo.Equals('S'))
            {
                return true;
            }
            return false;
        }

        public async Task<Periodo> GetPeriodoAsync(int IDPeriodo)
        {
            return await _periodoRepository.GetPeriodoAsync(IDPeriodo);
        }
    }
}
