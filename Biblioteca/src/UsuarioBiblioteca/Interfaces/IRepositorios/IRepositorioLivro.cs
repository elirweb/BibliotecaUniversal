using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Interfaces.IRepositorios
{
    public interface IRepositorioLivro
    {
        void Adicionar(Livro lv);

     

        bool TituloUnico(Livro lv);
        bool EstaAtiva(Livro model);
    }
}
