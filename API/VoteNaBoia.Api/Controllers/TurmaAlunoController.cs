using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL.Infra;
using VoteNaBoia.Entities;
using VoteNaBoia.Entities.DTO;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaAlunoController : ControllerBase
    {
        private ITurmaAlunoBLL _turmaAlunoBLL;
        public TurmaAlunoController(ITurmaAlunoBLL turmaAlunoBLL)
        {
            _turmaAlunoBLL = turmaAlunoBLL;
        }

        /// <summary>
        /// PERSISTIR DADOS DO ALUNO
        /// </summary>
        /// <param name="turmaAluno">OBJETO Turma ALUNO</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route(""), HttpPost]
        public async Task<IActionResult> Post([FromBody] TurmaAlunoDTO turmaAluno)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _turmaAlunoBLL.LinkTurmaAlunoAsync(new TurmaAluno(IDTurmaAluno: 0, IDAluno: turmaAluno.IDAluno, IDTurma: turmaAluno.IDTurma, DTVinculo: DateTime.Today, SNAprovado: 'N', SNModerador: 'N'));
                responseContent.Message = "Aluno vinculado a turma.";
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
        /// <param name="aluno">OBJETO aluno</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("{idTurmaAluno}"), HttpPut]
        public async Task<IActionResult> Put([FromBody] TurmaAlunoDTO turmaAluno, int idTurmaAluno)
        {
            var responseContent = new ResponseContent();

            if (idTurmaAluno != turmaAluno.IDTurmaAluno)
            {
                responseContent.Message = "Inconsistencia na informação enviada.";
                return BadRequest(responseContent);
            }

            try
            {
                await _turmaAlunoBLL.UpdateTurmaAlunoAsync(new TurmaAluno(IDTurmaAluno: turmaAluno.IDTurmaAluno, IDAluno: turmaAluno.IDAluno, IDTurma: turmaAluno.IDTurma, DTVinculo: turmaAluno.DTVinculo, SNAprovado: turmaAluno.SNAprovado, SNModerador: turmaAluno.SNModerador));
                responseContent.Message = "Cadastro do TurmaAluno alterado com sucesso!!";
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

        [Route("{idAluno}/turmas"), HttpGet]
        public async Task<IActionResult> Get(int idAluno)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _turmaAlunoBLL.GetAllTurmasAlunoAsync(idAluno);

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

        [Route("{idTurma}/alunos"), HttpGet]
        public async Task<IActionResult> GetAlunosTurma(int idTurma)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _turmaAlunoBLL.GetAllAlunosTurmaAsync(idTurma);

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

        [Route(""), HttpGet]
        public async Task<IActionResult> Get(int IDTurmaAluno, int IDTurma, int IDAluno)
        {
            var responseContent = new ResponseContent();

            try
            {
                
                if ((IDTurmaAluno.ToString() != null) &&
                    (IDTurmaAluno > 0))
                {
                    responseContent.Object = await _turmaAlunoBLL.GetTurmaAlunoAsync(IDTurmaAluno);
                }
                else if((IDTurma > 0) &&
                        (IDAluno > 0))
                {
                    responseContent.Object = await _turmaAlunoBLL.GetTurmaAlunoAsync(IDAluno, IDTurma);
                }
                else
                {
                    responseContent.Message = "A pesquisa não retornou dados";
                    return NotFound(responseContent);
                }

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
