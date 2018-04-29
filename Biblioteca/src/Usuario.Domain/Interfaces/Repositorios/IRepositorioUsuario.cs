
namespace Usuario.Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario
    {
        void Adicionar(Entidade.Usuario usuario);
        bool cpfunico(Entidade.Usuario usuario);
        bool Authenticar(Entidade.Usuario usuario);
        bool RecuperarSenha(string email);
        bool AlteracaoSenha(string senha,string email);

        bool loginunico(Entidade.Usuario usuario);
    }
}
