using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioAdministrador : Interfaces.IRepositorios.IRepositorioAdministrador
    {
        private readonly Contexto.Contexto contexto;
        public RepositorioAdministrador(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Administradores ad)
        {
            throw new NotImplementedException();
        }
    }
}
