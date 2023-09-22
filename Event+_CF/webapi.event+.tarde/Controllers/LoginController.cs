using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.ViewModels;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Realiza um login
        /// </summary>
        /// <param name="usuario">Usuário Logado</param>
        /// <returns>Token</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos");
                }

                //Caso encontre o usuárip buscado, prossegue para a criação do token

                //1- Definir as informaçoes(claims) que serão fornecidos no token (payload)
                var claims = new[]
                { 
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!),

                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor Personalizado")
                };

                //2- Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-chave-autenticacao-webapi-dev"));

                //3- Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4- Gerar o token
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.event+.tarde",

                    //Destinatário
                    audience: "webapi.event+.tarde",

                    //Dados definidos na claim (Payload)
                    claims: claims,

                    //Tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                //5- Retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

