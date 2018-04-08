using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Interfaces.Erros
{
    public interface INivel
    {
        string Descricao { get;  }

        string ToString();
    }
}
