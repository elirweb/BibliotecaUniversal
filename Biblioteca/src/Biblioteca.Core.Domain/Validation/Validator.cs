using Biblioteca.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Validation
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        public ValidationResult Validate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Add(string nome, IRule<TEntity> rule)
        {
            throw new NotImplementedException();
        }

       

        
    }
}
