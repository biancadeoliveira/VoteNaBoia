using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IVotoDiarioBLL: IDisposable
    {
        Task<Restaurante> GetResultadoVotoDiarioAsync(int idTurma);
        Task InsertVotoDiarioAsync(Voto voto);
        Task<List<Restaurante>> GetVotoDiarioRestaurantesAsync(int idTurma);
        Task<bool> IsAlunoJaVotouAsync(int idPeriodoDiario, int idTurmaAluno);

    }
}
