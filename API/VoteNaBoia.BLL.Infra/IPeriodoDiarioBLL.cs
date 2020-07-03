using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IPeriodoDiarioBLL : IDisposable
    {
        Task<PeriodoDiario> GetUltimoPeriodoAsync(int IDPeriodo);
        Task AbrirPeriodo(int IDTurma);
        Task FecharPeriodo(int IDTurma);
        Task<bool> IsPeriodoAbertoAsync(int IDPeriodoDiario);
    }
}
