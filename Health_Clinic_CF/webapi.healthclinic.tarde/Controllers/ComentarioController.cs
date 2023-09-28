using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository { get; set; }

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        /// <summary>
        /// Cadastra um novo comentário
        /// </summary>
        /// <param name="comentario">Objeto cadastrado</param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);

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
        /// <returns></returns>
        [HttpGet("Listar")]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
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
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_comentarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um comentário
        /// </summary>
        /// <param name="id">Id do comentário que deseja deletar</param>
        /// <returns></returns>
        [HttpDelete("Deletar{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
