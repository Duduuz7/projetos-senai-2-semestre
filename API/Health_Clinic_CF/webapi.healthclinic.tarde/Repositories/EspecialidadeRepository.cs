using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthContext;

        public EspecialidadeRepository()
        {
            _healthContext = new HealthContext();
        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Especialidade.FirstOrDefault(x => x.IdEspecialidade == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                _healthContext.Especialidade.Add(especialidade);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Especialidade especialidadeBuscada = _healthContext.Especialidade.Find(id)!;

            if (especialidadeBuscada != null)
            {
                _healthContext.Especialidade.Remove(especialidadeBuscada);
            }

            _healthContext.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            try
            {
                return _healthContext.Especialidade.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
