using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Entidades;

namespace UsuarioBiblioteca.Especificacao
{
    public class BibliotecaDevePossuiCNPJUnico : Biblioteca.Core.Domain.Interfaces.IEspecificacao<Entidades.Bibliotecaria>
    {
        private readonly Interfaces.IRepositorios.IRepositorioBibliotecaria _repositorio;

        public BibliotecaDevePossuiCNPJUnico(Interfaces.IRepositorios.IRepositorioBibliotecaria repo_)
        {
            _repositorio = repo_;
        } 
        public bool Satisfeito(Bibliotecaria model)
        {
            return _repositorio.CNPJUnico(model);
        }
    }
}
