using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IPeriodoRepository : IRepository
    {
        Task<Periodo> GetPeriodoAsync(int IDPeriodo);
        Task<Periodo> GetUltimoPeriodoAsync(int IDTurma);
        Task<List<Periodo>> GetAllPeriodosTurmaAsync(int IDTurma);
        void AbrirPeriodo(Periodo periodo);
        void FecharPeriodo(Periodo periodo);
    }
}
