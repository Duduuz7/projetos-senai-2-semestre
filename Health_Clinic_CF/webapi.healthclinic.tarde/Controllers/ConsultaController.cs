using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="consulta">Objeto cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201, consulta);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="id">id da consulta que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas de um determinado paciente
        /// </summary>
        /// <param name="id">id do paciente que deseja listar as consultas</param>
        /// <returns>status Code</returns>
        [HttpGet("ListarPaciente{id}")]
        public IActionResult GetPaciente(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.ListarMinhasPaciente(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas de um determinado paciente
        /// </summary>
        /// <param name="id">id do médico que deseja listar as consultas</param>
        /// <returns>status Code</returns>
        [HttpGet("ListarMedico{id}")]
        public IActionResult GetMedico(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.ListarMinhasMedico(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cancela uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que deseja cancelar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("CancelarConsulta{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Cancelar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que deseja atualizar</param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [HttpPut("Atualizar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
