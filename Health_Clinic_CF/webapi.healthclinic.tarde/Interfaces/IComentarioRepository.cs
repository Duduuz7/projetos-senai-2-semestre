using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);
        void Deletar(Guid id);
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
    }
}
