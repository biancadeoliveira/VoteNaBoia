using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.Helpers;

namespace VoteNaBoia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private IFormaPagamentoBLL _formaPagamentoBLL;
        public FormaPagamentoController(IFormaPagamentoBLL formaPagamentoBLL)
        {
            _formaPagamentoBLL = formaPagamentoBLL;
        }

        [Route(""), HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _formaPagamentoBLL.GetAllFormaPagamentoAsync();

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