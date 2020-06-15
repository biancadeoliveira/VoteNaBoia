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
    public class CadRestauranteController : ControllerBase
    {
        private ICadRestauranteBLL _cadRestauranteBLL;
        public CadRestauranteController(ICadRestauranteBLL cadRestauranteBLL)
        {
            _cadRestauranteBLL = cadRestauranteBLL;
        }

        /// <summary>
        /// PERSISTIR DADOS DO RESTAURANTE
        /// </summary>
        /// <param name="cadRestaurante">OBJETO CADRESTAURANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("post"),HttpPost]
        public async Task<IActionResult> Post([FromBody] CadRestauranteDTO cadRestaurante)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _cadRestauranteBLL.CreateCadRestauranteAsync(new CadRestaurante(id:0,nome:cadRestaurante.RestNome,tipo:cadRestaurante.RestTipo,idTurma:cadRestaurante.RestIdTurma,endereco:cadRestaurante.RestEndereco,telefone:cadRestaurante.RestTelefone, link:cadRestaurante.RestLink, email: cadRestaurante.RestEmail, ativo:cadRestaurante.RestAtivo));
                responseContent.Message = "Restaurante cadastrado com sucesso!!";
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
        /// <param name="cadRestaurante">OBJETO CADRESTAURANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("put"),HttpPut]
        public async Task<IActionResult> Put([FromBody] CadRestauranteDTO cadRestaurante) 
        {
            var responseContent = new ResponseContent();

            try
            {
                await _cadRestauranteBLL.UpdateCadRestauranteAsync(new CadRestaurante(id: cadRestaurante.RestId, nome: cadRestaurante.RestNome, tipo: cadRestaurante.RestTipo, idTurma: cadRestaurante.RestIdTurma, endereco: cadRestaurante.RestEndereco, telefone: cadRestaurante.RestTelefone, link: cadRestaurante.RestLink, email: cadRestaurante.RestEmail, ativo: cadRestaurante.RestAtivo));
                responseContent.Message = "Cadastro do restaurante alterado com sucesso!!";
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

        [Route("get"), HttpGet]
        public async Task<IActionResult> Get(int idRestaurante) 
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _cadRestauranteBLL.GetCadRestauranteAsync(idRestaurante);

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
    }
}