using Biblioteca.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Validation
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        public Rule(IEspecificacao<TEntity> model, string msg)
        {

        }  
        public string ErrorMessage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Validate(TEntity entity)
        {
            throw new NotImplementedException();
        }

     

    }


}
