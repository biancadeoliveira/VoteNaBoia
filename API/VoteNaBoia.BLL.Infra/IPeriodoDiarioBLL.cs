using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IPeriodoDiarioBLL : IDisposable
    {
        Task<PeriodoDiario> GetUltimoPeriodoDiarioAsync(int IDPeriodo);
        Task AbrirPeriodoDiario(int IDTurma);
        Task FecharPeriodoDiario(int IDTurma);
        Task<bool> IsPeriodoAbertoAsync(int IDPeriodoDiario);
    }
}
