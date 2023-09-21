using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext= new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                instituicaoBuscada.Endereco = instituicao.Endereco;
            }

            _eventContext.Update(instituicaoBuscada!);

            _eventContext.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(id)!;

            try
            {
                if (instituicaoBuscado != null)
                {
                    _eventContext.Instituicao.Remove(instituicaoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Instituicao> Listar()
        {
            return _eventContext.Instituicao.ToList();
        }
    }
}