using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Administrador
    {
        public Guid Id { get;  set; }
        [Required(ErrorMessage ="Favor informar o Nome")]
        public string Nome { get;  set; }

        [Required(ErrorMessage ="Favor informar o E-mail eletrônico")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get;  set; }
        
        [Display(Name ="Confirmar Email")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        [Compare("Email",ErrorMessage = "Email informado está diferente")]
        public string ConfirmEmail { get; set; }
        [Required(ErrorMessage ="Favor informar o Login")]
        public string Login { get;  set; }

        [Required(ErrorMessage ="Favor informar a Senha")]
        [Display(Name ="Senha")]
        public string Senha { get;  set; }
        public string Grupo { get;  set; } // role de usuario

        [Compare("Senha", ErrorMessage = "Senha informada não está correta")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmaSenha { get; set; }

        public List<string> ListaErros { get; set; }
        public Administrador()
        {
            ListaErros = new List<string>();
        }

        public string Error { get; set; }
    }
}
