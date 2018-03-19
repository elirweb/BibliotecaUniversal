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
        public const int celular = 9;
        public const int telefone = 8;
        public Contato(int numero,string tipo)
        {
            if (numero.ToString().Length.Equals(celular.ToString().Length))
                tipo = "celular";
            else
                tipo = "telefone";
            Numero = numero;
        }


    }
}
