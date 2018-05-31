using Usuario.Test.Entidade;
using Usuario.Test.Interfaces;

namespace Usuario.Test.DomainService
{
    public class UsuarioServico: IUsuario
    {
        private readonly IUsuarioRepositorio repositorio;
        public UsuarioServico(IUsuarioRepositorio repo)
        {
            repositorio = repo;
        }

        public void AdicionarUsuario(Entidade.Usuario u)
        {
            repositorio.AdicionarUsuario(u);
        }

        public RetornoMsg RetornaSucesso(Entidade.Usuario usuario)
        {

            if (usuario == null) return new RetornoMsg("Erro na gravação de dados");
            return new RetornoMsg("Dados Gravado com sucesso", usuario.IdUsuario);
        }
    }
}
