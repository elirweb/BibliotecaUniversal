using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Bibliotecaria
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }

        public string ConfirmaSenha { get; private set; }
        public string Email { get; private set; }

        public bool Situacao { get; private set; }
        public string Imagem { get; private set; }
     
    }
}
