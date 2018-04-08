using Dapper;

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

        public bool cpfunico(Domain.Entidade.Usuario usuario)
        {
           var cn = contexto.Database.Connection;
           var query = $"SELECT Cpf FROM Usuario WHERE Cpf = '{usuario.Cpf.Codigo}' ";
            var obj = cn.ExecuteScalar(query);
            if (obj != null)
                return true;
            return false;
        }
    }
}
