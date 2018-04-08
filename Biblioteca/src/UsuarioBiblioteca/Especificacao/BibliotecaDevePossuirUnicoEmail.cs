
using System;
using UsuarioBiblioteca.Entidades;

namespace UsuarioBiblioteca.Especificacao
{
    public class BibliotecaDevePossuirUnicoEmail 
    {
        private readonly Interfaces.IRepositorios.IRepositorioBibliotecaria repo;
        public BibliotecaDevePossuirUnicoEmail(Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio)
        {
            repo = repositorio;
        }
        public bool Satisfeito(Bibliotecaria model)
        {
            return repo.CNPJUnico(model);
        }
    }
}
