using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);
        void Deletar(Guid id);
        List<Especialidade> Listar();
        Especialidade BuscarPorId(Guid id);
    }
}
