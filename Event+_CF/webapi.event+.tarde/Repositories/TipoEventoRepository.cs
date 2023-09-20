using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoBuscado = _eventContext.TipoEvento.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoEvento.Titulo;
            }

            _eventContext.Update(tipoBuscado!);

            _eventContext.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                _eventContext.TipoEvento.Add(tipoEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {

            TipoEvento tipoBuscado = _eventContext.TipoEvento.Find(id)!;

            try
            {
                if (tipoBuscado != null)
                {
                    _eventContext.TipoEvento.Remove(tipoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> Listar()
        {
            try
            {
                return _eventContext.TipoEvento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
