using Biblioteca.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Interfaces
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
