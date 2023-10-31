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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="clinica">Objeto cadastrado</param>
        /// <returns>Status Code e objeto cadastrado</returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return StatusCode(201, clinica);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="id">Id da clinica que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
