using System;
using Biblioteca.Core.Domain.Helper;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioBibliotecaria: Biblioteca.Core.Domain.Util.Dispose, Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria
    {
      
        private readonly Contexto.Contexto contexto;
        private DbHelper helper = new DbHelper();
        public RepositorioBibliotecaria(Contexto.Contexto cont)
        {
            contexto = cont;
        }
        
        public void Adicionar(Domain.Entidades.Bibliotecaria bibliotecaria)
        {

            contexto.Bibliotecaria.Add(bibliotecaria);
        }

        public bool CNPJUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
            var obj = helper.ExecuteScalar($"SELECT Cnpj FROM Bibliotecaria WHERE Cnpj = '{bibliotecaria.Cnpj.Numero}' ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }
        
        public bool EmailUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
            var obj = helper.ExecuteScalar($"SELECT Email FROM Bibliotecaria WHERE Email = '{bibliotecaria.Email.Endereco}' ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

      

        public bool LoginUnico(Domain.Entidades.Bibliotecaria bibliotecaria)
        {
            var obj = helper.ExecuteScalar($"SELECT Usuario FROM Bibliotecaria WHERE Usuario = '{bibliotecaria.Usuario}' ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }
    }
}
