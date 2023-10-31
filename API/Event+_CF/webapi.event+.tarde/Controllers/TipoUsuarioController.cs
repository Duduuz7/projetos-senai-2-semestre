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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto cadastrado</param>
        /// <returns>Status Code e objeto cadastrado</returns>
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201, tipoUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Status Code e lista com todos os tipos de usuários</returns>
        [HttpGet("Listar")]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário que deseja deletar</param>
        /// <returns>Status Code</returns>
        [HttpDelete("Deletar{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return  NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário pelo seu Id
        /// </summary>
        /// <param name="id">Id do tipo de usuário que deseja buscar</param>
        /// <returns>Status Code e objeto com tipo de usuário buscado</returns>
        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="id">id do tipo de usuário que deseja atualizar</param>
        /// <param name="tipoUsuario"></param>
        /// <returns>Status Code</returns>
        [HttpPut("Atualizar{id}")]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario) 
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);

                return  NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
