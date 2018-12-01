using System;
using System.Data.Entity;
using Biblioteca.Core.Domain.Helper;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioBibliotecaria: Biblioteca.Core.Domain.Util.DisposeElement, Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria
    {
      
        private readonly Contexto.Contexto _contexto;
        private DbHelper _helper = new DbHelper();
        public RepositorioBibliotecaria(Contexto.Contexto cont)
        {
            _contexto = cont;
        }
        
        public void Adicionar(Domain.Entidades.Bibliotecaria bibliotecaria)
        {

            _contexto.Bibliotecaria.Add(bibliotecaria);
        }

        public void Atualizar(Bibliotecaria bi)
        {
            _contexto.Entry(bi).State = EntityState.Modified;
        }

        public bool Authenticar(Bibliotecaria bi)
        {
            var obj = _helper.ExecuteScalar($"SELECT Usuario,Senha FROM Bibliotecaria WHERE Usuario = '{bi.Usuario}'  and  Senha = '{bi.Senha}'", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        public bool CNPJUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
            var obj = _helper.ExecuteScalar($"SELECT Cnpj FROM Bibliotecaria WHERE Cnpj = '{bibliotecaria.Cnpj._cnpj}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        

        public bool EmailUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
            var obj = _helper.ExecuteScalar($"SELECT Email FROM Bibliotecaria WHERE Email = '{bibliotecaria.Email.Endereco}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

      

        public bool LoginUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
            var obj = _helper.ExecuteScalar($"SELECT Usuario FROM Bibliotecaria WHERE Usuario = '{bibliotecaria.Usuario}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }
    }
}
