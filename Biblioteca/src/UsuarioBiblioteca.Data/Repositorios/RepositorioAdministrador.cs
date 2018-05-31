using Biblioteca.Core.Domain.Helper;
using System;
using UsuarioBiblioteca.Domain.Entidades;

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

        public bool Authenticar(Administradores model)
        {
            var obj = helper.ExecuteScalar($"SELECT Login,Senha FROM Administradores WHERE Login = '{model.Login}' and Senha='{model.Senha}' ", contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
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
