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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuarioRepository { get; set; }

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo prontuário
        /// </summary>
        /// <param name="prontuario">Objeto cadastrado</param>
        /// <returns>Status Code e objeto cadastrado</returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Médico")]
        public IActionResult Post(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);

                return StatusCode(201, prontuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um prontuário pelo seu Id
        /// </summary>
        /// <param name="id">Id do prontuário que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_prontuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um prontuário
        /// </summary>
        /// <param name="id">Id do prontuário que deseja excluir</param>
        /// <returns></returns>
        [HttpDelete("Deletar{id}")]
        [Authorize(Roles = "Médico")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um prontuário
        /// </summary>
        /// <param name="id">Id do prontuário que deseja atualizar</param>
        /// <param name="prontuario">Objeto atualizado</param>
        /// <returns>Status Codes</returns>
        [HttpPut("Atualizar")]
        [Authorize(Roles = "Médico")]
        public IActionResult Put(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
