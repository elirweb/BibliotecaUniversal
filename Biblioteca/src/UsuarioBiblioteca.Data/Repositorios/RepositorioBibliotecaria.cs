using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioBibliotecaria: Interfaces.IRepositorios.IRepositorioBibliotecaria
    {
        private readonly Contexto.Contexto _contexto;
        public RepositorioBibliotecaria(Contexto.Contexto cont)
        {
            _contexto = cont;
        }
        
        public void Adicionar(Bibliotecaria bibliotecaria)
        {
            
            throw new NotImplementedException();
        }
    }
}
