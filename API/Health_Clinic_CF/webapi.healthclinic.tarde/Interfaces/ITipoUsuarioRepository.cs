using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(Guid id);
    }
}
