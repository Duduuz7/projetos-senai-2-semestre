using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;

        public ConsultaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.DataAgendamento = consulta.DataAgendamento;
                consultaBuscada.HorarioAgendamento = consulta.HorarioAgendamento;
                consultaBuscada.IdPaciente = consulta.IdPaciente;
                consultaBuscada.IdMedico = consulta.IdMedico;
            }

            _healthContext.Update(consultaBuscada!);

            _healthContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Consulta.FirstOrDefault(x => x.IdConsulta == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthContext.Consulta.Add(consulta);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cancelar(Guid id) //Deletar
        {
            Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {
                _healthContext.Consulta.Remove(consultaBuscada);
            }

            _healthContext.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            try
            {
                return _healthContext.Consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> ListarMinhasMedico(Guid id)
        {
            try
            {
                return _healthContext.Consulta.Where(x => x.IdMedico == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> ListarMinhasPaciente(Guid id)
        {
            try
            {
                return _healthContext.Consulta.Where(x => x.IdPaciente == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
