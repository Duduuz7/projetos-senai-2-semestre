using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencaEventoRepository= new PresencaEventoRepository();
        }

        /// <summary>
        /// Inscreve uma nova presença
        /// </summary>
        /// <param name="presenca"></param>
        /// <returns>Status Code</returns>
        [HttpPost("Inscrever")]
        public IActionResult Post(PresencaEvento presenca)
        {
            try
            {
                _presencaEventoRepository.Inscrever(presenca);

                return StatusCode(201, presenca);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Status Code</returns>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaEventoRepository.Listar()!);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as presenças de um usuário
        /// </summary>
        /// <param name="id">Id da presenca que deseja listar</param>
        /// <returns></returns>
        [HttpGet("ListarMinhas{id}")]
        public IActionResult GetMy(Guid id)
        {
            try
            {
                return Ok(_presencaEventoRepository.ListarMinhas(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma presença
        /// </summary>
        /// <param name="id">id da presença que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _presencaEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma presença pelo seu id
        /// </summary>
        /// <param name="id">id do usuário que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma presença
        /// </summary>
        /// <param name="id">id da presença que deseja atualizaf</param>
        /// <param name="presenca">presença buscada</param>
        /// <returns>Status Code</returns>
        [HttpPut("Atualizar")]
        public IActionResult Put(Guid id, PresencaEvento presenca) 
        {
            try
            {
                _presencaEventoRepository.Atualizar(id, presenca);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
