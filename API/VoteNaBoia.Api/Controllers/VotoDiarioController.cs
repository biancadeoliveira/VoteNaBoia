using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.Entities;
using VoteNaBoia.Entities.DTO;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoDiarioController : ControllerBase
    {
        private IVotoDiarioBLL _votoDiarioBLL;
        private IPeriodoDiarioBLL _periodoDiarioBLL;
        public VotoDiarioController(IVotoDiarioBLL votoDiarioBLL, IPeriodoDiarioBLL periodoDiarioBLL)
        {
            _votoDiarioBLL = votoDiarioBLL;
            _periodoDiarioBLL = periodoDiarioBLL;
        }


        [Route(""), HttpPost]
        public async Task<IActionResult> Post([FromBody] VotoDiarioDTO votoDiario)
        {
            var responseContent = new ResponseContent();

            try
               
            {
                await _votoDiarioBLL.InsertVotoDiarioAsync(new VotoDiario(id:0,idPeriodoResultado:votoDiario.IDPeriodoResultado,idTurmaAluno:votoDiario.IDTurmaAluno,dataHora:votoDiario.DHInclusao));
                responseContent.Message = "Voto cadastrado com sucesso!!";
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

        // ROTA PARA PEGAR RESTAURANTES DISPONÍVEIS PARA VOTAÇÃO DIÁRIA
        [Route("{idTurma}/{data}"), HttpGet]
        public async Task<IActionResult> Get(int idTurma)
        {
            var responseContent = new ResponseContent();
            try
            {   
                responseContent.Object = await _votoDiarioBLL.GetVotoDiarioRestaurantesAsync(idTurma);

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


        // ROTA PARA MOSTRAR O RESTAURANTE VENCEDOR
        [Route("resultado/{idTurmaAluno}/{data}"), HttpGet]
        public async Task<IActionResult> GetResultado(int idTurmaAluno)
        {
            var responseContent = new ResponseContent();

            try
            {
                DateTime data = new DateTime(2020,06,20);
                responseContent.Object = await _votoDiarioBLL.GetVotoDiarioAsync(idTurmaAluno,data);

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