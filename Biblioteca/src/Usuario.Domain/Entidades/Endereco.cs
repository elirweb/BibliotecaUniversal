using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Domain.Entidades
{
    public class Endereco:Base.BasePrincipal
    {
        public string Localidade { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }

        public virtual Usuario Usuario { get; private set; }
    }
}
