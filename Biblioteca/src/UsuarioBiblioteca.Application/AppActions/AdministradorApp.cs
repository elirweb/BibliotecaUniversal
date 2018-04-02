
using UsuarioBiblioteca.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class AdministradorApp: Interfaces.IAdministrador
    {
        private readonly IRepositorioAdministrador repositorio;

        public AdministradorApp(IRepositorioAdministrador adm)
        {
            repositorio = adm;
        }
    }
}
