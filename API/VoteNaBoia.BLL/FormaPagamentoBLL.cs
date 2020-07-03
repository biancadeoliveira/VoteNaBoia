using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class FormaPagamentoBLL : IFormaPagamentoBLL
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        public FormaPagamentoBLL(IFormaPagamentoRepository formaPagamentoRepository)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        public void Dispose()
        {
            _formaPagamentoRepository?.Dispose();
        }

        public async Task<List<FormaPagamento>> GetAllFormaPagamentoAsync()
        {
            return await _formaPagamentoRepository.GetAllFormaPagamentoAsync();
        }
    }
}
