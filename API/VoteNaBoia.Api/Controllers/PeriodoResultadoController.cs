using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoResultadoController : ControllerBase
    {
        private IPeriodoResultadoBLL _periodoResultadoBLL;

        public PeriodoResultadoController(IPeriodoResultadoBLL periodoResultadoBLL)
        {
            _periodoResultadoBLL = periodoResultadoBLL;
        }

        [Route("{idPeriodo}"), HttpGet]
        public async Task<IActionResult> Get(int idPeriodo)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _periodoResultadoBLL.GetAllRestaurantesPeriodoAsync(idPeriodo);
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

        [Route("{idPeriodo}/N"), HttpGet]
        public async Task<IActionResult> GetN(int idPeriodo)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _periodoResultadoBLL.GetAllRestaurantesNVisitadosAsync(idPeriodo);
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
