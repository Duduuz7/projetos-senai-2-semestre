using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituicao);
        void Deletar(Guid id);
        List<Instituicao> Listar();
        Instituicao BuscarPorId(Guid id);
        void Atualizar(Guid id, Instituicao instituicao);
    }
}
