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
    public class RestauranteController : ControllerBase
    {
        private IRestauranteBLL _restauranteBLL;
        public RestauranteController(IRestauranteBLL restauranteBLL)
        {
            _restauranteBLL = restauranteBLL;
        }


        [Route(""),HttpPost]
        public async Task<IActionResult> Post([FromBody] RestauranteDTO restaurante)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _restauranteBLL.CreateRestauranteAsync(new Restaurante(id:0,nome:restaurante.NMNome,tipo: restaurante.NMTipo,idTurma: restaurante.IDTurma,endereco: restaurante.Endereco,telefone: restaurante.NOTelefone, link: restaurante.Link, email: restaurante.Email, ativo: restaurante.SNAtivo));
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

        [Route("{id}"),HttpPut]
        public async Task<IActionResult> Put([FromBody] RestauranteDTO restaurante, int id) 
        {
            var responseContent = new ResponseContent();

            if(id != restaurante.IDRestaurante)
            {
                responseContent.Message = "Inconsistência na informação recebida";
                return BadRequest(responseContent);
            }

            try
            {
                await _restauranteBLL.UpdateRestauranteAsync(new Restaurante(id: restaurante.IDRestaurante, nome: restaurante.NMNome, tipo: restaurante.NMTipo, idTurma: restaurante.IDTurma, endereco: restaurante.Endereco, telefone: restaurante.NOTelefone, link: restaurante.Link, email: restaurante.Email, ativo: restaurante.SNAtivo));
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


        [Route("{id}/update/ativo"), HttpPut]
        public async Task<IActionResult> PutStatus([FromBody] RestauranteDTO restaurante, int id)
        {
            var responseContent = new ResponseContent();

            if (id != restaurante.IDRestaurante)
            {
                responseContent.Message = "Inconsistência na informação recebida.";
                return BadRequest(responseContent);
            }

            try
            {
                var msg = await _restauranteBLL.UpdateStatusRestauranteAsync(restaurante.IDRestaurante, restaurante.SNAtivo);

                if (!msg.Equals(""))
                {
                    responseContent.Message = msg;
                    return BadRequest(responseContent);
                }

                
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

        [Route("{id}"), HttpGet]
        public async Task<IActionResult> Get(int id) 
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _restauranteBLL.GetRestauranteByIdAsync(id);

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

        [Route("{idTurma}/{nome}"), HttpGet]
        public async Task<IActionResult> GetByName(string nome, int idTurma)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _restauranteBLL.GetRestauranteByNameAsync(nome, idTurma);

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

        [Route("{idTurma}"), HttpGet]
        public async Task<IActionResult> GetAll(int idTurma)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _restauranteBLL.GetAllRestauranteAsync(idTurma);

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