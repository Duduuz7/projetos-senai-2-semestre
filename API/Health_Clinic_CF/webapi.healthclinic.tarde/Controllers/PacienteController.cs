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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="paciente">Objeto cadastrado</param>
        /// <returns>Status Code e objeto cadastrado</returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201, paciente);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um paciente pelo seu Id
        /// </summary>
        /// <param name="id">Id do paciente que deseja buscar</param>
        /// <returns></returns>
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">Id do paciente que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
