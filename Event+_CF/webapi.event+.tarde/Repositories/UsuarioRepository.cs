using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.FirstOrDefault(x => x.Email == email)!;

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
                Usuario usuarioBuscado = _eventContext.Usuario.Select(x => new Usuario
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
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
