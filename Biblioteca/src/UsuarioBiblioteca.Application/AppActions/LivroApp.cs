
using UsuarioBiblioteca.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class LivroApp: Interfaces.ILivro
    {
        private readonly IRepositorioLivro repositorio;
        public LivroApp(IRepositorioLivro lv)
        {
            repositorio = lv;
        }
    }
}
