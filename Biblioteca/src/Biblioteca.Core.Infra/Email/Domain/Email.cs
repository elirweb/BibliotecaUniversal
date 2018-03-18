using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Infra.Email.Domain
{
    public class Email
    {
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Assunto { get; private set; }
        public string Mensagem { get; private set; }
    }
}
