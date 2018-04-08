
namespace Usuario.Domain.Especificacao
{
    public class UsuarioDevePossuirUnicoCPF : Biblioteca.Core.Domain.Interfaces.Especificacao.IEspecificacao<Entidade.Usuario>
    {
        private readonly Interfaces.Repositorios.IRepositorioUsuario repositorio;
        public UsuarioDevePossuirUnicoCPF(Interfaces.Repositorios.IRepositorioUsuario repo)
        {
            
            repositorio = repo;
        }

        public bool InSatisfeito(Entidade.Usuario model)
        {
            return repositorio.cpfunico(model);
        }
    }
}
