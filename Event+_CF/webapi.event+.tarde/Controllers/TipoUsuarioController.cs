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
    //[Authorize]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost("Cadastrar")]
        //[Authorize(Roles = "6DAAA960-160B-4895-AB43-CA641A088F8B")]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

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

        [HttpDelete("Deletar{id}")]
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
