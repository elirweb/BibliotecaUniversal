using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Application.ViewModel
{
    public class EnderecoUsuario
    {
        [Required(ErrorMessage ="Favor informar a localidade")]
        public string Localidade { get;  set; }
        [Required(ErrorMessage = "Favor informar o bairro")]
        public string Bairro { get;  set; }
        [Required(ErrorMessage = "Favor informar o Numero")]
        public int Numero { get;  set; }
        [Required(ErrorMessage = "Favor informar a Cidade")]
        public string Cidade { get;  set; }
        [Required(ErrorMessage = "Favor informar o Uf")]
        public string Uf { get;  set; }

        public Usuario IdUsuario { get; set; }

        public EnderecoUsuario()
        {
            IdUsuario = new Usuario();
        }

    }
}
