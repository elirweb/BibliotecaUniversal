using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.ValueObjects
{
    public class Contato
    {
        public int Numero { get; private set; }

        public Contato(int numero)
        {
            Numero = numero;
        }
    }
}
