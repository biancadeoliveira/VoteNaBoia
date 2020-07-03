using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.DAL.Infra
{
    public interface IFormaPagamentoRepository : IRepository
    {
        Task<List<FormaPagamento>> GetAllFormaPagamentoAsync();
    }
}
