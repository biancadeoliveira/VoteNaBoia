using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface IFormaPagamentoBLL : IDisposable
    {
        Task<List<FormaPagamento>> GetAllFormaPagamentoAsync();

    }
}
