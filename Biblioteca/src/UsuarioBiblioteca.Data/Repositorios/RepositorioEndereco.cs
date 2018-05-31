using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioEndereco : Biblioteca.Core.Domain.Util.Dispose, Domain.Interfaces.IRepositorios.IRepositorioEndereco
    {
        private readonly Contexto.Contexto _contexto;
        public RepositorioEndereco(Contexto.Contexto context)
        {
            _contexto = context;
        }
        public void Adicionar(Domain.Entidades.Endereco endereco)
        {
            _contexto.Endereco.Add(endereco);
        }
    }
}
