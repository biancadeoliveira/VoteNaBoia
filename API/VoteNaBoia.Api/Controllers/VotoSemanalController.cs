using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
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
        public async Task<IActionResult> Post(int IDTurmaAluno, int IDRestaurante, int IDPeriodo)
        {
            var responseContent = new ResponseContent();

            try
            {
                if(await _votoSemanalBLL.AddVotoSemanal(IDTurmaAluno, IDRestaurante, IDPeriodo))
                {
                    responseContent.Message = "Restaurante cadastrado com sucesso!!";
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


        [Route("resultado"), HttpPost]
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
