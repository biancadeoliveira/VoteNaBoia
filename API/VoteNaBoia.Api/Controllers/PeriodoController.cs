using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VoteNaBoia.BLL;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL;
using VoteNaBoia.Entities;
using VoteNaBoia.Helpers;
using VoteNaBoia.DAL.DataBaseContext;

namespace VoteNaBoia.Api.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private IPeriodoBLL _periodoBLL;
        
        public PeriodoController(IPeriodoBLL periodoBLL)
        {
            _periodoBLL = periodoBLL;
        }
        
        /// <summary>
        /// PERSISTIR DADOS DO ALUNO
        /// </summary>
        /// <param name="periodo">OBJETO Periodo</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("{id}/abrir"), HttpPost]
        public async Task<IActionResult> Post(int id)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _periodoBLL.AbrirPeriodo(id);
                responseContent.Message = "Periodo aberto.";
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

        [Route("{id}/fechar"), HttpPut]
        public async Task<IActionResult> Put(int id)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _periodoBLL.FecharPeriodo(id);
                responseContent.Message = "Periodo fechado.";
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
                responseContent.Object = await _periodoBLL.GetUltimoPeriodoAsync(id);
                responseContent.Message = "";
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

        [Route("{id}/all"), HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _periodoBLL.GetAllPeriodosTurmaAsync(id);
                responseContent.Message = "";
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
