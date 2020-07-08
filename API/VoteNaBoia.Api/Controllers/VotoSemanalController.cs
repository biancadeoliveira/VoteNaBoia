using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.Entities.DTO;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoSemanalController : ControllerBase
    {
        private IVotoSemanalBLL _votoSemanalBLL;
        public VotoSemanalController(IVotoSemanalBLL votoSemanalBLL)
        {
            _votoSemanalBLL = votoSemanalBLL;
        }

        /// <summary>
        /// PERSISTIR DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="votosemanal">OBJETO Voto Semanal</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route(""), HttpPost]
        public async Task<IActionResult> Post([FromBody] VotoSemanalDTO votoSemanal)
        {
            var responseContent = new ResponseContent();

            try
            {
                if(await _votoSemanalBLL.AddVotoSemanal(votoSemanal.IDTurmaAluno, votoSemanal.IDRestaurante, votoSemanal.IDPeriodo))
                {
                    responseContent.Message = "Voto semanal cadastrado com sucesso!!";
                    return Ok(responseContent);
                }
                responseContent.Message = "Erro ao efetuar votação";
                return BadRequest(responseContent);
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

        [Route("{idPeriodo}/{idTurmaAluno}"), HttpGet]
        public async Task<IActionResult> GetAlunosTurma(int idPeriodo, int idTurmaAluno)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _votoSemanalBLL.GetVotoSemanal(idPeriodo, idTurmaAluno);

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

        [Route("processar/{idPeriodo}"), HttpPost]
        public async Task<IActionResult> Post(int IDPeriodo)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _votoSemanalBLL.CalcResultVotoSemanal(IDPeriodo);
                responseContent.Message = "Votação calculada com sucesso!!";
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
