using System;
using System.Collections.Generic;
using System.Text;

namespace VoteNaBoia.Entities.DTO
{
    public class PagamentoRestauranteDTO
    {
        public int IDPagamentoRestaurante { get; set; }
        public int IDRestaurante { get; set; }
        public int IDFormaPagamento { get; set; }
    }
}
