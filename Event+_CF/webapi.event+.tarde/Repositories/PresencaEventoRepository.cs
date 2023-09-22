using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaBuscada = _eventContext.PresencaEvento.Find(id)!;

            if (presencaBuscada != null)
            {
                presencaBuscada.Situacao = presencaEvento.Situacao;
                presencaBuscada.IdUsuario = presencaEvento.IdUsuario;
                presencaBuscada.IdEvento = presencaEvento.IdEvento;
            }

            _eventContext.Update(presencaBuscada!);

            _eventContext.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.PresencaEvento.FirstOrDefault(x => x.IdPresencaEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaBuscada = _eventContext.PresencaEvento.Find(id)!;

            try
            {
                if (presencaBuscada != null)
                {
                    _eventContext.PresencaEvento.Remove(presencaBuscada);
                }

                _eventContext.SaveChanges();    
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                _eventContext.PresencaEvento.Add(inscricao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                return _eventContext.PresencaEvento
                    .Select(x => new PresencaEvento
                    {
                        IdPresencaEvento = x.IdPresencaEvento,
                        Situacao= x.Situacao,

                        Usuario = new Usuario
                        {
                            IdUsuario= x.IdUsuario,
                            Nome = x.Usuario!.Nome,
                        },

                        Evento = new Evento
                        {
                            IdEvento = x.IdEvento,
                            NomeEvento = x.Evento!.NomeEvento
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            try
            {
                return _eventContext.PresencaEvento.Where(x => x.IdUsuario == id).Select(x => new PresencaEvento
                {
                    IdPresencaEvento = x.IdPresencaEvento,
                    Situacao = x.Situacao,

                    Usuario = new Usuario
                    {
                        IdUsuario = x.IdUsuario,
                        Nome = x.Usuario!.Nome,
                    },

                    Evento = new Evento
                    {
                        IdEvento = x.IdEvento,
                        NomeEvento = x.Evento!.NomeEvento
                    }

                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
