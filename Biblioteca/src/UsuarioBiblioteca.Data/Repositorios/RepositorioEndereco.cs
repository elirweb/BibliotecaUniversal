using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioEndereco : Biblioteca.Core.Domain.Util.DisposeElement, Domain.Interfaces.IRepositorios.IRepositorioEndereco
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

        public void Atualizar(Endereco endereco)
        {
            _contexto.Entry(endereco).State = EntityState.Modified;
        }
    }
}
