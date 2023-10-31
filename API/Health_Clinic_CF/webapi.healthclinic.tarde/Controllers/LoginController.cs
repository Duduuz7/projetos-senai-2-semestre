using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;
using webapi.healthclinic.tarde.ViewModels;

namespace webapi.healthclinic.tarde.Controllers
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
        /// Efetua Login
        /// </summary>
        /// <param name="usuario">Objeto com o usuário que deseja se logar</param>
        /// <returns></returns>
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
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-chave-autenticacao-webapi-dev"));

                //3- Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4- Gerar o token
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.healthclinic.tarde",

                    //Destinatário
                    audience: "webapi.healthclinic.tarde",

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
