using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        void Cancelar(Guid id); //Deletar
        List<Consulta> Listar();
        Consulta BuscarPorId(Guid id);
        void Atualizar(Guid id, Consulta consulta);
        List<Consulta> ListarMinhasPaciente(Guid id);
        List<Consulta> ListarMinhasMedico(Guid id);
    }
}
