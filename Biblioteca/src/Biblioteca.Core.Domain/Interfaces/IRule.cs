using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Interfaces
{
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }

        bool Validate(TEntity entity);


    }
}
