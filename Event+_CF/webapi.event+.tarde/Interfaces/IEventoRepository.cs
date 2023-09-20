using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        void Deletar(Guid id);
        List<Evento> Listar();
        Evento BuscarPorId(Guid id);
        void Atualizar(Guid id, Evento evento);
    }
}
