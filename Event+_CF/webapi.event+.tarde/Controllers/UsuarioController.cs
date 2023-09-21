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
        /// <param name="usuario">Objeto com novo usuário cadastrado</param>
        /// <returns>Status Code e objeto com o usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario) 
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Busca um usuário pelo seu Id
        /// </summary>
        /// <param name="id">Id do usuário que deseja buscar</param>
        /// <returns>Status Code e objeto com usuário buscado</returns>
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
        /// <returns>Status Code e objeto com usuário buscado</returns>
        [HttpGet("BuscarPorEmailEsenha")]
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
    }
}
