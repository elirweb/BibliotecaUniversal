using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Application.ViewModel
{
    public class Usuario
    {
        [Required(ErrorMessage ="Favor informar Nome")]
        public string Nome { get;  set; }
        [Required(ErrorMessage = "Favor informar Login")]
        public string Login { get;  set; }
        [Required(ErrorMessage = "Favor informar Senha")]
        public string Senha { get;  set; }
        [Required(ErrorMessage = "Favor informar Confirma Senha")]
        [Compare("Senha",ErrorMessage ="Senha informada não está correta")]
        public string ConfirmaSenha { get;  set; }

        [Required(ErrorMessage ="Favor informar o E-mail eletronico")]
        [EmailAddress(ErrorMessage ="Email invalido")]
        public string Email { get;  set; }

        [Required(ErrorMessage ="Favor informar o CPF")]
        public string Cpf { get;  set; }

        public string Error { get; set; }

        public Guid Id { get; set; }

    }
}
