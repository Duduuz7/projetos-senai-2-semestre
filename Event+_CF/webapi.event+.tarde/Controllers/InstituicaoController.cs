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

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Objeto com a instituição a ser cadastrada</param>
        /// <returns>Status Code e a nova instituição cadastrada</returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return StatusCode(201, instituicao);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as instituições
        /// </summary>
        /// <returns>Status code e uma lista com todas as instituições</returns>
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

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">Id da instituição que deseja deletar</param>
        /// <returns>Status Code</returns>
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

        /// <summary>
        /// Busca uma instituição pelo seu id
        /// </summary>
        /// <param name="id">Id da instituição que deseja buscar</param>
        /// <returns>Status Code e a instituição buscado</returns>
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

        /// <summary>
        /// Atualiza uma instituição
        /// </summary>
        /// <param name="id">Id da insitituição que deseja atualizar</param>
        /// <param name="instituicao"></param>
        /// <returns>Status Code</returns>
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
