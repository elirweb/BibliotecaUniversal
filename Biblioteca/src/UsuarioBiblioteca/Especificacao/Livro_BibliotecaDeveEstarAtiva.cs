
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Especificacao
{
    public class Livro_BibliotecaDeveEstarAtiva : Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Livro>
    {
        private readonly Interfaces.IRepositorios.IRepositorioLivro repo;

        public Livro_BibliotecaDeveEstarAtiva(Interfaces.IRepositorios.IRepositorioLivro repositorio)
        {
            repo = repositorio;
        }

        public bool InSatisfeito(Livro model)
        {
            return repo.EstaAtiva(model);
        }
    }
}
