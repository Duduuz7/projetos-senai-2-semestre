using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public TipoUsuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _healthContext.TipoUsuario.Add(tipoUsuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoUsuario tipoBuscado = _healthContext.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                _healthContext.Remove(tipoBuscado);
            }

            _healthContext.SaveChanges();
        }
    }
}
