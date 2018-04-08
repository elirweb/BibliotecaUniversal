using System.Threading.Tasks;

namespace Biblioteca.Core.Infra.Email.Interfaces
{
    public interface IEnvioEmail
    {
        Task EnviarAsync(Domain.Email email);
    }
}
