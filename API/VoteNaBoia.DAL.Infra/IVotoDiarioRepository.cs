using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IVotoDiarioRepository:IRepository
    {
        // Task<List<VotoDiario>> GetResultadoVotoDiarioAsync(DateTime DHInclusao);
        int GetResultadoVotoDiarioAsync(int idPeriodoDiario);
        Task<VotoDiario> GetVotoDiarioAsync(int idPeriodoDiario, int idTurmaAluno);
        void InsertVotoDiarioAsync(VotoDiario votoDiario);
    }
}
