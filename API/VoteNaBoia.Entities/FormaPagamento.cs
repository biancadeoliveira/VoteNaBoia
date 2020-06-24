using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Formas_Pagamento")]
    public class FormaPagamento
    {
        [Key]
        [Column("ID_Forma_Pagamento")]
        public int IDFormaPagamento { get; private set; }

        [Required]
        [Column("NM_Forma_Pagamento",TypeName ="varchar(30)")]
        public string NMFormaPagamento { get; private set; }

        protected FormaPagamento() { }

        public FormaPagamento(int id, string descricao) 
        {
            this.IDFormaPagamento = id;
            this.NMFormaPagamento = descricao;
        }
    }
}
