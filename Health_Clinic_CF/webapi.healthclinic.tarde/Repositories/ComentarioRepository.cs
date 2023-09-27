using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthContext _healthContext;

        public ComentarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                return _healthContext.Comentario.FirstOrDefault(x => x.IdComentario == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                _healthContext.Comentario.Add(comentario);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Comentario comentarioBuscado = _healthContext.Comentario.Find(id)!;

            if (comentarioBuscado != null)
            {
                _healthContext.Comentario.Remove(comentarioBuscado);
            }

            _healthContext.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            try
            {
                return _healthContext.Comentario.ToList();
            }
            catch (Exception)
            {
                throw;
            }  
        }
    }
}
