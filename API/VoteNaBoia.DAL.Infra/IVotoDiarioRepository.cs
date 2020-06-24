using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IVotoDiarioRepository:IRepository
    {
        Task<List<VotoDiario>> GetResultadoVotoDiarioAsync(DateTime DHInclusao);
        void InsertVotoDiarioAsync(VotoDiario votoDiario);
    }
}
