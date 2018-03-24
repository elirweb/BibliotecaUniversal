using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioEndereco : Interfaces.IRepositorios.IRepositorioEndereco
    {
        private readonly Contexto.Contexto _contexto;
        public RepositorioEndereco(Contexto.Contexto context)
        {
            _contexto = context;
        }
        public void Adicionar(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
