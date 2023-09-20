using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext= new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            }

            _eventContext.Update(eventoBuscado!);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.Evento.FirstOrDefault(x => x.IdEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            try
            {
                _eventContext.Evento.Remove(eventoBuscado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _eventContext.Evento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
