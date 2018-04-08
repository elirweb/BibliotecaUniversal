
namespace Usuario.Domain.Interfaces.Repositorios
{
    public interface IRepositorioUsuario
    {
        void Adicionar(Entidade.Usuario usuario);

        bool cpfunico(Entidade.Usuario usuario);  
    }
}
