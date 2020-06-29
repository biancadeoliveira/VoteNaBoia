using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IPeriodoDiarioRepository : IRepository
    {
        Task<PeriodoDiario> GetPeriodoAsync(int IDPeriodo);
        Task<PeriodoDiario> GetUltimoPeriodoAsync(int IDPeriodo);
        Task<List<PeriodoDiario>> GetAllPeriodosAsync(int IDPeriodo);
        void AbrirPeriodo(PeriodoDiario periodoDiario);
        void FecharPeriodo(PeriodoDiario periodoDiario);
        Task<bool> IsPeriodoAbertoAsync(int IDPeriodo);
    }
}
