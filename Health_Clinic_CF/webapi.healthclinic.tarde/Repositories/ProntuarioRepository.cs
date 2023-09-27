using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthContext _healthContext;

        public ProntuarioRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            Prontuario prontuarioBuscado = _healthContext.Prontuario.Find(id)!;

            if (prontuarioBuscado != null)
            {
                prontuarioBuscado.Descricao = prontuario.Descricao;
                prontuarioBuscado.IdMedico = prontuario.IdMedico;
                prontuarioBuscado.IdConsulta = prontuario.IdConsulta;
            }

            _healthContext.Update(prontuarioBuscado!);

            _healthContext.SaveChanges();
        }

        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Prontuario.FirstOrDefault(x => x.IdPronturario == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Prontuario prontuario)
        {
            try
            {
                _healthContext.Prontuario.Add(prontuario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Prontuario prontuarioBuscado = _healthContext.Prontuario.Find(id)!;

            if (prontuarioBuscado != null)
            {
                _healthContext.Prontuario.Remove(prontuarioBuscado);
            }

            _healthContext.SaveChanges();
        }
    }
}
