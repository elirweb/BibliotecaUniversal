
using System;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Especificacao
{
    public class BibliotecaDevePossuirUnicoEmail: Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Bibliotecaria>
    {
        private readonly Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria repo;
        public BibliotecaDevePossuirUnicoEmail(Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio)
        {
            repo = repositorio;
        }

        public bool InSatisfeito(Bibliotecaria model)
        {
            return repo.EmailUnico(model);
        }

       
    }
}
