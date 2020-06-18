
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;

namespace VoteNaBoia.BLL
{
    public class AlunoBLL:IAlunoBLL
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoBLL(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR PERSISTIR O CADASTRO DO Aluno
        /// </summary>
        /// <param name="aluno">OBJETO ALUNO</param>
        /// <returns></returns>
        public async Task CreateAlunoAsync(Aluno aluno)
        {
            _alunoRepository.CreateAlunoAsync(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR O CADASTRO DO ALUNO
        /// </summary>
        /// <param name="IDAluno">ID DO ALUNO</param>
        /// <returns>OBJETO ALUNO</returns>
        public async Task<Aluno> GetAlunoAsync(int IDAluno)
        {
            //VERIFICAR SE OS DADOS QUE SERÃO CONSTRUÍDOS ESTÃO OK
            new Aluno(0,"", "", "",' ',' ');

            return await _alunoRepository.GetAlunoAsync(IDAluno);
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR RETORNAR TODOS OS DO ALUNOS
        /// </summary>
        /// <param name="IDAluno">ID DO ALUNO</param>
        /// <returns>OBJETO ALUNO</returns>
        public async Task<List<Aluno>> GetAllAlunoAsync()
        {
            //VERIFICAR SE OS DADOS QUE SERÃO CONSTRUÍDOS ESTÃO OK
            new List<Aluno>();

            return await _alunoRepository.GetAllAlunoAsync();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O CADASTRO DO ALUNO
        /// </summary>
        /// <param name="aluno">OBJETO ALUNO</param>
        /// <returns></returns>
        public async Task UpdateAlunoAsync(Aluno aluno)
        {
            _alunoRepository.UpdateAlunoAsync(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL POR ATUALIZAR O CADASTRO DO ALUNO
        /// </summary>
        /// <param name="aluno">OBJETO ALUNO</param>
        /// <returns></returns>
        public async Task<string> UpdateStatusAlunoAsync(int IDAluno, char SNAtivo)
        {
            if(!(SNAtivo.Equals('S')) && !(SNAtivo.Equals('N')))
            {
                return "SNAtivo deve ser S ou N";
            }
            
            var aluno = await this.GetAlunoAsync(IDAluno);
            aluno.setSNAtivo(SNAtivo);
            
            _alunoRepository.UpdateAlunoAsync(aluno);
            await _alunoRepository.UnitOfWork.Commit();

            return "";
        }
    }
}
