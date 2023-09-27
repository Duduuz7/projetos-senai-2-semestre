using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;

        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthContext.Clinica.Add(clinica);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Clinica clinicaBuscada = _healthContext.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                _healthContext.Clinica.Remove(clinicaBuscada);
            }

            _healthContext.SaveChanges();
        }
    }
}
