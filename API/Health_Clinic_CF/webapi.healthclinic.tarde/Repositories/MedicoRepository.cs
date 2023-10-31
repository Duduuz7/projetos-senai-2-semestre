using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;

        public MedicoRepository()
        {
            _healthContext = new HealthContext();
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Medico.FirstOrDefault(x => x.IdMedico == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthContext.Medico.Add(medico);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscado = _healthContext.Medico.Find(id)!;

            if (medicoBuscado != null)
            {
                _healthContext.Medico.Remove(medicoBuscado);
            }

            _healthContext.SaveChanges();
        }

        public List<Medico> Listar()
        {
            try
            {
                return _healthContext.Medico.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
