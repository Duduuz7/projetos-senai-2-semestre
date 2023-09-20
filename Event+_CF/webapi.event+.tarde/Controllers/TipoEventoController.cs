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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoEventoRepository.Listar());
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
                _tipoEventoRepository.Deletar(id);

                return NoContent();
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
                return Ok(_tipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("Atualizar{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento) 
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
