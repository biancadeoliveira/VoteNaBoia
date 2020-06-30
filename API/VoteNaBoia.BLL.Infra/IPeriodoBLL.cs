using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IPeriodoBLL : IDisposable
    {
        Task<Periodo> GetUltimoPeriodoAsync(int IDTurma);
        Task<List<Periodo>> GetAllPeriodosTurmaAsync(int IDTurma);
        Task<Periodo> GetPeriodoAsync(int IDPeriodo);
        Task AbrirPeriodo(int IDTurma);
        Task FecharPeriodo(int IDTurma);
        Task<bool> IsPeriodoAbertoAsync(int IDPeriodo);
    }
}
