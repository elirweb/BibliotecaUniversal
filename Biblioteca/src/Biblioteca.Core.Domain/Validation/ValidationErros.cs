using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Validation
{
    public class ValidationError
    {
        public ValidationError(string message){}
        public string Message { get; set; }
    }
}
