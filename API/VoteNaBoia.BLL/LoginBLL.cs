using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class LoginBLL : ILoginBLL
    {
        private readonly ILoginRepository _loginRepository;
        public LoginBLL(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void Dispose()
        {
            _loginRepository?.Dispose();
        }

        public async Task<Aluno> GetAlunoLoginAsync(string email, string senha)
        {
            var msg = "";
            var aluno = await _loginRepository.GetAlunoLoginAsync(email,senha);
            if(aluno != null) 
            {
                if (aluno.SNAtivo.Equals('S'))
                {
                    return aluno;
                }
                else
                {
                    msg = "Aluno inativo";
                    throw new Exception(msg);
                }
            }
            else
            {
                msg = "Aluno não encontrado! Verifique o usuário e senha.";
                throw new Exception(msg);
            }
        }
    }
}
