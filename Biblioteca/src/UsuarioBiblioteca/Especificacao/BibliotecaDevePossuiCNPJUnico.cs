using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Especificacao
{
    public class BibliotecaDevePossuiCNPJUnico: Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Bibliotecaria>
    {
        private readonly Interfaces.IRepositorios.IRepositorioBibliotecaria _repositorio;

        public BibliotecaDevePossuiCNPJUnico(Interfaces.IRepositorios.IRepositorioBibliotecaria repo_)
        {
            _repositorio = repo_;

        }
      

        public bool InSatisfeito(Bibliotecaria model)
        {
            return _repositorio.CNPJUnico(model);
            
        }
    }
}
