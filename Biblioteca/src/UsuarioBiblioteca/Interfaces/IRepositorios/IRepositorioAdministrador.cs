
using System;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Interfaces.IRepositorios
{
    public interface IRepositorioAdministrador: IDisposable
    {
        void Adicionar(Entidades.Administradores ad);
        bool LoginUnico(Administradores model);
        bool Authenticar(Administradores model);
    }
}
