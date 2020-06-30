using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface ITurmaConfiguracaoBLL : IDisposable
    {
        Task<TurmaConfiguracao> GetTurmaConfiguracaoAsync(int IDTurma);
        Task<bool> CreateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao);
        Task<bool> UpdateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao);
    }
}
