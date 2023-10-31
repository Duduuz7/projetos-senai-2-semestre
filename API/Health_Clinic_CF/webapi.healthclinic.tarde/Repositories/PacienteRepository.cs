using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;

        public PacienteRepository()
        {
            _healthContext = new HealthContext();
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Paciente.FirstOrDefault(x => x.IdPaciente == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthContext.Paciente.Add(paciente);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = _healthContext.Paciente.Find(id)!;

            if (pacienteBuscado != null)
            {
                _healthContext.Paciente.Remove(pacienteBuscado);
            }

            _healthContext.SaveChanges();
        }
    }
}
