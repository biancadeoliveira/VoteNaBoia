using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Entities
{
    [Table("Restaurantes")]
    public class Restaurante
    {
        [Key]
        [Column("ID_Restaurante")]
        public int IDRestaurante { get;  set; }

        [Required]
       // [ForeignKey("ID_Turma")]
        [Column("ID_Turma")]
        public int IDTurma { get;  set; }

        [Required]
        [Column("NM_Restaurante", TypeName ="varchar(100)")]
        public string NMNome { get;  set; }

        [Required]
        [Column("NM_Tipo",TypeName ="varchar(100)")]
        public string NMTipo { get;  set; }

        [Required]
        [Column("Endereco",TypeName ="varchar(255)")]
        public string Endereco { get;  set; }

        [Column("NO_Telefone",TypeName ="varchar(12)")]
        public string NOTelefone { get;  set; }

        [Column("Link",TypeName ="varchar(255)")]
        public string Link { get;  set; }

        [Column("Email",TypeName ="varchar(255)")]
        public string Email { get;  set; }

        [Required]
        [Column("SN_Ativo",TypeName ="char(1)")]
        public char SNAtivo { get;  set; }

        [ForeignKey("IDTurma")]
        public Turma Turma { get; set; }

        public  ICollection<PagamentoRestaurante> PagamentoRestaurante { get; set; }
        protected Restaurante() { }

        public Restaurante(int id,string nome, string tipo,int idTurma, string endereco, string telefone, string link, string email, char ativo, ICollection<PagamentoRestaurante> PagamentoRestaurante) 
        {
            this.IDRestaurante = id;
            this.NMNome = nome;
            this.NMTipo = tipo;
            this.IDTurma = idTurma;
            this.Endereco = endereco;
            this.NOTelefone = telefone;
            this.Link = link;
            this.Email = email;
            this.SNAtivo = ativo;
            this.PagamentoRestaurante = PagamentoRestaurante;
        }

        private void Validations(string RestNome, string RestTipo, string RestEndereco) 
        {
            //if (string.IsNullOrWhiteSpace(RestNome)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
            //if (string.IsNullOrWhiteSpace(RestTipo)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
            //if (string.IsNullOrWhiteSpace(RestEndereco)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
        }
    }
}
