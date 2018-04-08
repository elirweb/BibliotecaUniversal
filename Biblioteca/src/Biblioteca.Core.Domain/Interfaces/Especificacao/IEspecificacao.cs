using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Interfaces.Especificacao
{
    public interface IEspecificacao<T> 
    {
        bool InSatisfeito(T model);
    }
}
