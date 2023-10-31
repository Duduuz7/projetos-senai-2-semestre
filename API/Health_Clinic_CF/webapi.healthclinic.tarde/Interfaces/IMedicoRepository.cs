using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        void Deletar(Guid id);
        List<Medico> Listar();
        Medico BuscarPorId(Guid id);
    }
}
