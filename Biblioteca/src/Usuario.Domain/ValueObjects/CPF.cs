using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Domain.ValueObjects
{
    public class CPF
    {
        public string Codigo { get; set; }

        public CPF(string codigo)
        {
            Codigo = codigo;
        }

        // implentar a validação do cpf
    }
}
