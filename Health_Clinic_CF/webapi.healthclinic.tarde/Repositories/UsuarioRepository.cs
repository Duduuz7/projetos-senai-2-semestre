using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Utils;

namespace webapi.healthclinic.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public UsuarioRepository()  
        {
            _healthContext = new HealthContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario
                    .Select(x => new Usuario
                    {
                        IdUsuario = x.IdUsuario,
                        Nome = x.Nome,
                        Email = x.Email,
                        Senha = x.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = x.IdTipoUsuario,
                            Titulo = x.TipoUsuario!.Titulo
                        }
                    })
                    .FirstOrDefault(x => x.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.Select(x => new Usuario
                {
                    IdUsuario = x.IdUsuario,
                    Nome = x.Nome,
                    Email = x.Email,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = x.IdTipoUsuario,
                        Titulo = x.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(x => x.IdTipoUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                _healthContext.Usuario.Add(usuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
