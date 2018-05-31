using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Especificacao
{
    public class LivroDevePossuirUnicoTitulo : Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Livro>
    {
        private readonly Interfaces.IRepositorios.IRepositorioLivro repo;

        public LivroDevePossuirUnicoTitulo(Interfaces.IRepositorios.IRepositorioLivro repositorio)
        {
            repo = repositorio;
        }

        public bool InSatisfeito(Livro model)
        {
            return repo.TituloUnico(model);
        }
    }
}
