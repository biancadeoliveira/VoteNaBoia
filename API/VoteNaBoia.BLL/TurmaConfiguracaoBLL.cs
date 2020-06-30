using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class TurmaConfiguracaoBLL : ITurmaConfiguracaoBLL
    {
        private readonly ITurmaConfiguracaoRepository _turmaConfiguracaoRepository;

        public TurmaConfiguracaoBLL(ITurmaConfiguracaoRepository turmaConfiguracaoRepository)
        {
            _turmaConfiguracaoRepository = turmaConfiguracaoRepository;
        }

        public void Dispose()
        {
            _turmaConfiguracaoRepository?.Dispose();
        }

        public async Task<bool> CreateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao)
        {
            _turmaConfiguracaoRepository.CreateTurmaConfiguracaoAsync(turmaConfiguracao);
            await _turmaConfiguracaoRepository.UnitOfWork.Commit();

            return true;
        }

        public async Task<TurmaConfiguracao> GetTurmaConfiguracaoAsync(int IDTurma)
        {
            return await _turmaConfiguracaoRepository.GetTurmaConfiguracaoAsync(IDTurma);
        }

        public async Task<bool> UpdateTurmaConfiguracaoAsync(TurmaConfiguracao turmaConfiguracao)
        {
            _turmaConfiguracaoRepository.UpdateTurmaConfiguracaoAsync(turmaConfiguracao);
            await _turmaConfiguracaoRepository.UnitOfWork.Commit();

            return true;
        }
    }
}
