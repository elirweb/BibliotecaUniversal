using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Endereco
    {
        public string tipo { get; set; }
        public Guid Id { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
        public int DDD { get; private set; }
        public string Telefone { get; private set; }
     

    }
}
