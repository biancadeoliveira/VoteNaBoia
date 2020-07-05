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
    public class LoginController : ControllerBase
    {
        private ILoginBLL _loginBLL;
        public LoginController(ILoginBLL loginBLL)
        {
            _loginBLL = loginBLL;
        }
      

        [Route("{email}/{senha}"), HttpGet]
        public async Task<IActionResult> Get(string email, string senha)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _loginBLL.GetAlunoLoginAsync(email,senha);

                responseContent.Message = "Aluno logado com sucesso!!";
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
