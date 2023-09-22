using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns>Status Code e novo tipo cadastrado</returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201, tipoEvento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Status Code e lista com todos os tipos de eventos</returns>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoEventoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">id do tipo de evento que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de evento pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de evento que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_tipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que deseja atualizar</param>
        /// <param name="tipoEvento">Objeto com tipo de evento atualizado</param>
        /// <returns></returns>
        [HttpPut("Atualizar{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento) 
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
