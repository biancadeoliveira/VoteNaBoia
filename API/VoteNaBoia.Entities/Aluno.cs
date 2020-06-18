using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VoteNaBoia.Entities
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        [Column("ID_Aluno")]
        public int IDAluno { get; private set; }

        [Required]
        [Column("NM_Aluno", TypeName = "varchar(100)")] 
        public string NMAluno { get; private set; }

        [Required]
        [Column("Email", TypeName = "varchar(255)")]
        public string Email { get; private set; }

        [Required]
        [Column("Senha", TypeName = "varchar(255)")]
        public string Senha { get; private set; }

        [Required]
        [Column("SN_Envia_Email", TypeName = "char(1)")]
        public char SNEnviaEmail { get; private set; }

        [Required]
        [Column("SN_Ativo", TypeName = "char(1)")]
        public char SNAtivo { get; private set; }

        protected Aluno() { }

        public Aluno(int IDAluno, string NMAluno, string Email, string Senha, char SNEnviaEmail, char SNAtivo)
        {
            //this.Validations(RestNome: nome, RestTipo: tipo, RestEndereco: endereco);

            this.IDAluno = IDAluno;
            this.NMAluno = NMAluno;
            this.Email = Email;
            this.Senha = Senha;
            this.SNEnviaEmail = SNEnviaEmail;
            this.SNAtivo = SNAtivo;
        }

        public void setSNAtivo(char SNAtivo)
        {
            this.SNAtivo = SNAtivo;
        }
        
        private void Validations(string RestNome, string RestTipo, string RestEndereco)
        {
            //if (string.IsNullOrWhiteSpace(RestNome)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
            //if (string.IsNullOrWhiteSpace(RestTipo)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
            //if (string.IsNullOrWhiteSpace(RestEndereco)) throw new BusinessException(message: "Preencha os campos obrigatórios.");
        }

    }
}
