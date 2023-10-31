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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto com novo usuário</param>
        /// <returns>Status Code e usuário cadastrado</returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário que deseja buscar</param>
        /// <returns>Status Code</returns>
        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu email e senha
        /// </summary>
        /// <param name="email">email do usuário que deseja buscar</param>
        /// <param name="senha">senha do usuário que deseja buscar</param>
        /// <returns></returns>
        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult GetByEmailAndPassword(string email, string senha) 
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorEmailESenha(email, senha));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //[HttpDelete("Deletar{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    try
        //    {
        //        _usuarioRepository.Deletar(id);

        //        return NoContent();
        //    }
        //    catch (Exception erro)
        //    {
        //        return BadRequest(erro.Message);
        //    }
        //}
    }
}
