using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext= new EventContext();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.Find(id)!;

            try
            {
                if (comentarioBuscado != null)
                {
                    _eventContext.ComentarioEvento.Remove(comentarioBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                return _eventContext.ComentarioEvento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
