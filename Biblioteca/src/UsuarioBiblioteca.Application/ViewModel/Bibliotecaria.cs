using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Bibliotecaria
    {
        public Guid Id { get; set; }
        
        [Display(Name ="Razão Social")]
        [Required(ErrorMessage ="Favor informar Razão Social")]
        public string RazaoSocial { get;  set; }
        [Required(ErrorMessage ="Favor informar Cnpj")]
        public string Cnpj { get;  set; }
        [Required(ErrorMessage ="Favor informar o Usuário")]
        public string Usuario { get;  set; }

        [Required(ErrorMessage = "Favor informar Confirma Senha")]

        public string Senha { get;  set; }
        [Required(ErrorMessage = "Favor informar Confirma Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "Senha informada não está correta")]
        public string ConfirmaSenha { get;  set; }
      
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get;  set; }
        [Display(Name ="Confirmar Email")]

        [Required(ErrorMessage = "Favor informar Confirmar Email")]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Senha informada não está correta")]

        public string ConfirmEmail { get; set; }
        [Required(ErrorMessage ="Favor informar ativação do livro")]
        public bool Situacao { get;  set; }

        [Required(ErrorMessage ="Favor informar a imagem")]
        public string Imagem { get;  set; }

        public List<string> ListaErros { get; set; }
        public Bibliotecaria()
        {
            ListaErros = new List<string>();
        }

        public IEnumerable<SelectListItem> ListStatus
        {
            get
            {
                return new[]
                {
                     new SelectListItem { Value = "0", Text = "Inativo" },
                     new SelectListItem { Value = "1", Text = "Ativo" }
                };
            }
        }
    }
}
