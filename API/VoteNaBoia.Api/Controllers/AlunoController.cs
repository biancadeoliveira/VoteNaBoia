using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteNaBoia.BLL;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.Entities;
using VoteNaBoia.Entities.DTO;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IAlunoBLL _alunoBLL;
        public AlunoController(IAlunoBLL alunoBLL)
        {
            _alunoBLL = alunoBLL;
        }

        /// <summary>
        /// PERSISTIR DADOS DO ALUNO
        /// </summary>
        /// <param name="aluno">OBJETO ALUNO</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route(""),HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoDTO aluno)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _alunoBLL.CreateAlunoAsync(new Aluno(IDAluno:0,NMAluno:aluno.NMAluno,Email:aluno.Email,Senha:aluno.Senha,SNEnviaEmail:'S',SNAtivo:'S'));
                responseContent.Message = "Aluno cadastrado com sucesso!!";
                return Ok(responseContent);
            }
            catch (BusinessException bex)
            {
                responseContent.Message = bex.Message;
                return BadRequest(responseContent);
            }
            catch (Exception ex)
            {
                responseContent.Message = ex.Message;
                return BadRequest(responseContent);
            }
        }

        /// <summary>
        /// ATUALIZAR DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="aluno">OBJETO CADRESTAURANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("{id}"),HttpPut]
        public async Task<IActionResult> Put([FromBody] AlunoDTO aluno, int id) 
        {
            var responseContent = new ResponseContent();
            
            if(id != aluno.IDAluno)
            {
                responseContent.Message = "Inconsistencia na informação enviada.";
                return BadRequest(responseContent);
            }
            
            try
            {
                await _alunoBLL.UpdateAlunoAsync(new Aluno(IDAluno: aluno.IDAluno, NMAluno: aluno.NMAluno, Email: aluno.Email, Senha: aluno.Senha, SNEnviaEmail: aluno.SNEnviaEmail, SNAtivo: aluno.SNAtivo));
                responseContent.Message = "Cadastro do aluno alterado com sucesso!!";
                return Ok(responseContent);
            }
            catch (BusinessException bex)
            {
                responseContent.Message = bex.Message;
                return BadRequest(responseContent);
            }
            catch (Exception ex)
            {
                responseContent.Message = ex.Message;
                return BadRequest(responseContent);
            }
        }

        /// <summary>
        /// ATUALIZAR SN_Ativo aluno 
        /// </summary>
        /// <param name="aluno">ID_Aluno, SN_Aluno</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("{id}/update/ativo"), HttpPut]
        public async Task<IActionResult> PutAtivo([FromBody] AlunoDTO aluno, int id)
        {
            var responseContent = new ResponseContent();

            if (id != aluno.IDAluno)
            {
                responseContent.Message = "Inconsistencia na informação enviada.";
                return BadRequest(responseContent);
            }

            try
            {
                var msg = await _alunoBLL.UpdateStatusAlunoAsync(aluno.IDAluno, aluno.SNAtivo);
                
                if(!msg.Equals(""))
                {
                    responseContent.Message = msg;
                    return BadRequest(responseContent);
                }
                
                responseContent.Message = "Cadastro do aluno alterado com sucesso!!";
                return Ok(responseContent);
                
            }
            catch (BusinessException bex)
            {
                responseContent.Message = bex.Message;
                return BadRequest(responseContent);
            }
            catch (Exception ex)
            {
                responseContent.Message = ex.Message;
                return BadRequest(responseContent);
            }
        }

        [Route("{id}"), HttpGet]
        public async Task<IActionResult> Get(int id) 
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _alunoBLL.GetAlunoAsync(id);

                if(responseContent.Object == null)
                {
                    responseContent.Message = "A pesquisa não retornou dados";
                    return NotFound(responseContent);
                }
                responseContent.Message = "Operação realizada com sucesso!!";
                return Ok(responseContent);
            }
            catch (BusinessException bex)
            {
                responseContent.Message = bex.Message;
                return BadRequest(responseContent);
            }
            catch (Exception ex)
            {
                responseContent.Message = ex.Message;
                return BadRequest(responseContent);
            }
        }

        [Route(""), HttpGet]
        public async Task<IActionResult> Get()
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _alunoBLL.GetAllAlunoAsync();

                if (responseContent.Object == null)
                {
                    responseContent.Message = "A pesquisa não retornou dados";
                    return NotFound(responseContent);
                }
                responseContent.Message = "Operação realizada com sucesso!!";
                return Ok(responseContent);
            }
            catch (BusinessException bex)
            {
                responseContent.Message = bex.Message;
                return BadRequest(responseContent);
            }
            catch (Exception ex)
            {
                responseContent.Message = ex.Message;
                return BadRequest(responseContent);
            }
        }
    }
}
