using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface ITurmaConfiguracaoRepository : IRepository
    {
        Task<TurmaConfiguracao> GetTurmaConfiguracaoAsync(int IDTurma);
        void CreateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao);
        void UpdateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao);       
    }
}
