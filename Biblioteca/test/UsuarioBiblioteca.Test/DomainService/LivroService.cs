using UsuarioBiblioteca.Test.Entidades;
using UsuarioBiblioteca.Test.Interfaces;

namespace UsuarioBiblioteca.Test.DomainService
{
    public class LivroService : ILivro
    {
        private readonly ILivroRepositorio repositorio;
        public LivroService(ILivroRepositorio repo)
        {
            repositorio = repo;
        }

        public void AdicionarLivro(Entidades.Livro u)
        {
            repositorio.AdicionarLivro(u);
        }

        public RetornoMsg RetornaSucesso(Entidades.Livro bi)
        {

            if (bi == null) return new RetornoMsg("Erro na gravação de dados");
            return new RetornoMsg("Dados Gravado com sucesso", bi.Id);
        }
    }
}

