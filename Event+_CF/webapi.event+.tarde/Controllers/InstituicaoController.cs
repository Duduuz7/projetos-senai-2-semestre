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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

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
                return Ok(_instituicaoRepository.Listar());
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
                _instituicaoRepository.Deletar(id);

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
                return Ok(_instituicaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("Atualizar{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao) 
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
