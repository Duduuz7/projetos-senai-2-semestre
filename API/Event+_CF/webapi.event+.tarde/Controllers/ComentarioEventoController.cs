using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _comentarioEventoRepository { get; set; }

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        /// <summary>
        /// Cadastra um novo comentário
        /// </summary>
        /// <param name="comentario">Comentário cadastrado</param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(ComentarioEvento comentario)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentario);

                return StatusCode(201, comentario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os comentários
        /// </summary>
        /// <returns>Status Code</returns>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar()!);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um comentário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um comentário pelo seu id
        /// </summary>
        /// <param name="id">id do comentário que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
