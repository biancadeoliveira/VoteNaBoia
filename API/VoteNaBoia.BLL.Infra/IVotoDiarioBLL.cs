using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IVotoDiarioBLL: IDisposable
    {
        // Task<List<VotoDiario>> GetAllVotoDiarioAsync(DateTime DHInclusao);
        Task<Restaurante> GetVotoDiarioAsync(int IDTurmaAluno,DateTime DHInclusao);
        Task InsertVotoDiarioAsync(VotoDiario votoDiario);
        Task<List<Restaurante>> GetVotoDiarioRestaurantesAsync(int idTurma);

    }
}
