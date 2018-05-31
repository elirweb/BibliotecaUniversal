using System;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Especificacao
{
    public class AdministradorDevePossuirUnicoLogin : Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Administradores>
    {
        private readonly Interfaces.IRepositorios.IRepositorioAdministrador _repositorio;
        public AdministradorDevePossuirUnicoLogin(Interfaces.IRepositorios.IRepositorioAdministrador repo)
        {
            _repositorio = repo;
        }

        public bool InSatisfeito(Administradores model)
        {
           return  _repositorio.LoginUnico(model);
        }
    }
}
