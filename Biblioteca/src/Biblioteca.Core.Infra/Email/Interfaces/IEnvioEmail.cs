using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Infra.Email.Interfaces
{
    public interface IEnvioEmail
    {
        Task EnviarAsync(Domain.Email email);
    }
}
