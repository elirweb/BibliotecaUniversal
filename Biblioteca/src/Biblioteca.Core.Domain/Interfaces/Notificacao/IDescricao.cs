using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Interfaces.Notificacao
{
    public interface IDescricao
    {
        string Menssage { get; }

        string ToString();
    }
}
