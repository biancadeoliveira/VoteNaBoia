using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IPeriodoDiarioBLL : IDisposable
    {
        Task<PeriodoDiario> GetUltimoPeriodoAsync(int IDTurma);
       // Task<List<Periodo>> GetAllPeriodosAsync(int IDTurma);
        Task AbrirPeriodo(int IDTurma);
        Task FecharPeriodo(int IDTurma);
        Task<bool> IsPeriodoAbertoAsync(int IDPeriodo);
    }
}
