using Biblioteca.Core.Domain.Helper;
using System;

namespace UsuarioBiblioteca.Data.Repositorios
{
    public class RepositorioAdministrador : Biblioteca.Core.Domain.Util.Dispose, Domain.Interfaces.IRepositorios.IRepositorioAdministrador
    {
        private readonly Contexto.Contexto contexto;
        private DbHelper helper = new DbHelper();
        public RepositorioAdministrador(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Domain.Entidades.Administradores ad)
        {
            contexto.Administradores.Add(ad);
        }

        public bool LoginUnico(Domain.Entidades.Administradores model)
        {
            var obj = helper.ExecuteScalar($"SELECT Login FROM Administradores WHERE Login = '{model.Login}' ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }
    }
}
