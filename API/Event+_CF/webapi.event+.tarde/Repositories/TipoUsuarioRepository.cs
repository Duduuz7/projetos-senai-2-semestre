using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoBuscado = _eventContext.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoUsuario.Titulo;
            }

            _eventContext.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoUsuario tipoBuscado = _eventContext.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                _eventContext.Remove(tipoBuscado);
            }

            _eventContext.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return _eventContext.TipoUsuario.ToList();
        }
    }
}
