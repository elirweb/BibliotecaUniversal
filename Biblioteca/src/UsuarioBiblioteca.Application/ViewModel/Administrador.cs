using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Administrador
    {
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        [Required(ErrorMessage ="Favor informar o E-mail eletrônico")]
        public string Email { get;  set; }
        
        [Display(Name ="Confirmar Email")]
        [Compare("Email",ErrorMessage = "Email informado está diferente")]
        public string ConfirmEmail { get; set; }
        public string Login { get;  set; }
        public Biblioteca.Core.Domain.ValueObjects.Senha Senha { get;  set; }
        public string Grupo { get;  set; } // role de usuario

        [Display(Name ="Confirmar Senha")]
        [Compare("Senha",ErrorMessage ="Favor verificar a senha, estão diferente")]
        public string ConfirmaSenha { get; set; }

        public List<string> ListaErros { get; set; }
        public Administrador()
        {
            ListaErros = new List<string>();
        }

        public string Error { get; set; }
    }
}
