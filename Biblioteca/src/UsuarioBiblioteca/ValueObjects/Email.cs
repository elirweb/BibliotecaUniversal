using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.ValueObjects
{
    public class Email
    {
        public string Endereco { get; private set; }

        public Email(string end)
        {
            if(IsValid(end))
                Endereco = end;
        }

        public bool IsValid(string end) {
            if (end.Contains("@"))
                return true;
            return false;
        }


    }
}
