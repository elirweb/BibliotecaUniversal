﻿
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Interfaces.IRepositorios
{
    public interface IRepositorioAdministrador
    {
        void Adicionar(Entidades.Administradores ad);
        bool LoginUnico(Administradores model);
    }
}
