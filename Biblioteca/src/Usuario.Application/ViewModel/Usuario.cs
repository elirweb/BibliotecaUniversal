using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Application.ViewModel
{
    public class Usuario
    {
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public string ConfirmaSenha { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

      
    }
}
