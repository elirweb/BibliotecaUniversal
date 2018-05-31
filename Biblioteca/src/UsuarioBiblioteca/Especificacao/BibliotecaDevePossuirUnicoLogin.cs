using System;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Especificacao
{
    public class BibliotecaDevePossuirUnicoLogin : Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Bibliotecaria>
    {
        private readonly Interfaces.IRepositorios.IRepositorioBibliotecaria repo;

        public BibliotecaDevePossuirUnicoLogin(Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio)
        {
            repo = repositorio;
        }

        public bool InSatisfeito(Bibliotecaria model)
        {

            return repo.LoginUnico(model);
          
        }
    }
}
