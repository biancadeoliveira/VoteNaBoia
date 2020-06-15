using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Entities
{
    [Table("Restaurantes")]
    public class CadRestaurante
    {
        [Key]
        [Column("ID_Restaurante")]
        public int RestId { get; private set; }

        [Column("ID_Turma")]
        public int RestIdTurma { get; private set; }

        [Column("NM_Restaurante")]
        public string RestNome { get; private set; }

        [Column("NM_Tipo")]
        public string RestTipo { get; private set; }

        [Column("Endereco")]
        public string RestEndereco { get; private set; }

        [Column("NO_Telefone")]
        public string RestTelefone { get; private set; }

        [Column("Link")]
        public string RestLink { get; private set; }

        [Column("Email")]
        public string RestEmail { get; private set; }

        [Column("SN_Ativo")]
        public string RestAtivo { get; private set; }

        protected CadRestaurante() { }

        public CadRestaurante(int id,string nome, string tipo,int idTurma, string endereco, string telefone, string link, string email, string ativo) 
        {
            this.Validations(RestNome: nome, RestTipo: tipo, RestEndereco: endereco);

            this.RestId = id;
            this.RestNome = nome;
            this.RestTipo = tipo;
            this.RestIdTurma = idTurma;
            this.RestEndereco = endereco;
            this.RestTelefone = telefone;
            this.RestLink = link;
            this.RestEmail = email;
            this.RestAtivo = ativo;
        }

        private void Validations(string RestNome, string RestTipo, string RestEndereco) 
        {
            if (string.IsNullOrWhiteSpace(RestNome)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
            if (string.IsNullOrWhiteSpace(RestTipo)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
            if (string.IsNullOrWhiteSpace(RestEndereco)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
        }
    }
}
