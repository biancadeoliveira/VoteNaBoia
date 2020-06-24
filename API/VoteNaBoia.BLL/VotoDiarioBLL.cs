using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class VotoDiarioBLL : IVotoDiarioBLL
    {
        private readonly IVotoDiarioBLL _votoDiarioRepository;

        public VotoDiarioBLL(IVotoDiarioBLL votoDiarioRepository)
        {
            _votoDiarioRepository = votoDiarioRepository;
        }
        public void Dispose()
        {
            _votoDiarioRepository?.Dispose();
        }

        public async Task<List<VotoDiario>> GetAllVotoDiarioAsync(DateTime DHInclusao)
        {
            return await _votoDiarioRepository.GetAllVotoDiarioAsync(DHInclusao);
        }

        public Task InsertVotoDiarioAsync(VotoDiario votoDiario)
        {
            throw new NotImplementedException();
        }
    }
}
