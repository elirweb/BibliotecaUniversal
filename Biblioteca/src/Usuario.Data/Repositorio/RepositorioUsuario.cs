using ELIR =  Biblioteca.Core.Domain.Helper;

namespace Usuario.Data.Repositorio
{
    public class RepositorioUsuario : Biblioteca.Core.Domain.Util.DisposeElement, Domain.Interfaces.Repositorios.IRepositorioUsuario
    {
        private ELIR.DbHelper _helper = new ELIR.DbHelper();
        private readonly Contexto.Contexto _contexto;
        public RepositorioUsuario(Contexto.Contexto coc)
        {
            _contexto = coc;
        }
        public void Adicionar(Domain.Entidade.Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
           
        }

        public bool AlteracaoSenha(string email,string senha)
        {
          
            var obj = _helper.ExecuteScalar($"SELECT Senha FROM Usuario WHERE Email = '{email}'  ", _contexto.Database.Connection);
            if(obj != null) {
                var senha_nova = new Biblioteca.Core.Domain.ValueObjects.Senha(senha);
                _helper.Execute($"UPDATE USUARIO SET Senha= '{senha_nova.CodigoSenha}' WHERE Email = '{email}' ", _contexto.Database.Connection);
                return true;
            }
            return false;
        }

        public bool Authenticar(Domain.Entidade.Usuario usuario)
        {
           
            var obj = _helper.ExecuteScalar($"SELECT Login,Senha FROM Usuario WHERE Login = '{usuario.Login}' and Senha= '{usuario.Senha.CodigoSenha }'  ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        public bool cpfunico(Domain.Entidade.Usuario usuario)
        {
            
            var obj = _helper.ExecuteScalar($"SELECT Cpf FROM Usuario WHERE Cpf = '{usuario.Cpf.Codigo}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        public bool loginunico(Domain.Entidade.Usuario usuario)
        {
           
            var obj = _helper.ExecuteScalar($"SELECT Login FROM Usuario WHERE Login = '{usuario.Login}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;
        }

        public bool RecuperarSenha(string email)
        {
           
            var obj = _helper.ExecuteScalar($"SELECT Email FROM Usuario WHERE Email = '{email}' ", _contexto.Database.Connection);
            if (obj != null)
                return true;
            return false;

        }
    }
}
