using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IVotoSemanalRepository : IRepository
    {
        void AddVotoSemanal(VotoSemanal votoSemanal);
        Task<List<VotoSemanal>> GetAllVotosPeriodoAsync(int IDPeriodo);
        Task<VotoSemanal> GetVotoSemanal(int IDVotoSemanal);
        Task<VotoSemanal> GetVotoSemanal(int IDPeriodo, int IDTurmaAluno);
    }
}
