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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; }

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="evento">Objeto cadastrado</param>
        /// <returns>Status Code e evento cadastrado</returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "6DAAA960-160B-4895-AB43-CA641A088F8B")]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return StatusCode(201, evento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os eventos cadastrados
        /// </summary>
        /// <returns>Status Code</returns>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">Id do evento que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um evento pelo seu id
        /// </summary>
        /// <param name="id">Id do evento que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um evento
        /// </summary>
        /// <param name="id">Id do evento que deseja atualizar</param>
        /// <param name="evento">Evento atualizado</param>
        /// <returns>Status Code</returns>
        [HttpPut("Atualizar{id}")]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
