using System;
using Dapper;
using Usuario.Domain.Entidade;
using System.Linq;
using System.Data.Entity;

namespace Usuario.Data.Repositorio
{
    public class RepositorioUsuario : Domain.Interfaces.Repositorios.IRepositorioUsuario
    {

        private readonly Contexto.Contexto contexto;
        public RepositorioUsuario(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Domain.Entidade.Usuario usuario)
        {
            contexto.Usuario.Add(usuario);
           
        }

        public bool AlteracaoSenha(string email,string senha)
        {
            var cn = contexto.Database.Connection;
            var retorno = false;
            var query = $"SELECT Senha FROM Usuario WHERE Email = '{email}'  ";
            var obj = cn.ExecuteScalar(query);
            if (obj != null)
            {
                var senha_nova = new Biblioteca.Core.Domain.ValueObjects.Senha(senha);

                cn.Execute($"UPDATE USUARIO SET Senha= '{senha_nova.CodigoSenha}' WHERE Email = '{email}' ");
                retorno = true;
            }

            return retorno;
        }

        public bool Authenticar(Domain.Entidade.Usuario usuario)
        {
            var cn = contexto.Database.Connection;
            var query = $"SELECT Login,Senha FROM Usuario WHERE Login = '{usuario.Login}' and Senha= '{usuario.Senha.CodigoSenha }'  ";
            var obj = cn.ExecuteScalar(query);
            if (obj != null)
                return true;
            return false;
        }

        public bool cpfunico(Domain.Entidade.Usuario usuario)
        {
           var cn = contexto.Database.Connection;
           var query = $"SELECT Cpf FROM Usuario WHERE Cpf = '{usuario.Cpf.Codigo}' ";
            var obj = cn.ExecuteScalar(query);
            if (obj != null)
                return true;
            return false;
        }

        public bool RecuperarSenha(string email)
        {
            var cn = contexto.Database.Connection;
            var query = $"SELECT Email FROM Usuario WHERE Email = '{email}' ";
            var obj = cn.ExecuteScalar(query);
            if (obj != null)
                return true;
            return false;
        }
    }
}
