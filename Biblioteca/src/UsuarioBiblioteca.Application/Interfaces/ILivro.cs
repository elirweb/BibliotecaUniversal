
namespace UsuarioBiblioteca.Application.Interfaces
{
    public interface ILivro
    {
        ViewModel.Livro Adicionar(ViewModel.Livro lv);
        void add(ViewModel.Livro lv,string token, out string retorno);
    }
}
