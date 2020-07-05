using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL.Infra
{
    public interface ILoginBLL : IDisposable
    {
        Task<Aluno> GetAlunoLoginAsync(string email, string senha);
    }
}
