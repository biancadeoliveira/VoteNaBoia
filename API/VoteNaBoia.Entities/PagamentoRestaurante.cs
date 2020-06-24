using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Pagamento_Restaurante")]
    public class PagamentoRestaurante
    {
        [Key]
        [Column("ID_Pagamento_Restaurante")]
        public int IDPagamentoRestaurante { get; private set; }

        [Required]
        [ForeignKey("ID_Restaurante")]
        [Column("ID_Restaurante")]
        public int IDRestaurante { get; private set; }

        [Required]
        [ForeignKey("ID_Forma_Pagamento")]
        [Column("ID_Forma_Pagamento")]
        public int IDFormaPagamento { get; private set; }

        public FormaPagamento FormaPagamento { get; set; }

        protected PagamentoRestaurante() { }

        public PagamentoRestaurante(int id, int idRestaurante, int idPagamento)
        {
            this.IDPagamentoRestaurante = id;
            this.IDRestaurante = idRestaurante;
            this.IDFormaPagamento = idPagamento;
        }
    }
}
