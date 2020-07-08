using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IVotoSemanalBLL : IDisposable
    {
        Task<bool> AddVotoSemanal(int IDTurmaAluno, int IDRestaurante, int IDPeriodo);
        Task<bool> CalcResultVotoSemanal(int IDPeriodo);
        Task<List<VotoSemanal>> GetAllVotosPeriodoAsync(int IDPeriodo);
        Task<VotoSemanal> GetVotoSemanal(int IDVotoSemanal);
        Task<List<VotoSemanal>> GetVotoSemanal(int IDPeriodo, int IDTurmaAluno);
    }
}
