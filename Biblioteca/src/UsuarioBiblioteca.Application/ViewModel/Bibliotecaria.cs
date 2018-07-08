using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Bibliotecaria
    {
        public Guid Id { get; set; }
        
        [Display(Name ="Razão Social")]
        [Required(ErrorMessage ="Favor informar Razão Social")]
        public string RazaoSocial { get;  set; }
        [Display(Name ="Cnpj")]
        [Required(ErrorMessage ="Favor informar Cnpj")]
        public string Cnpj { get;  set; }
        [Required(ErrorMessage ="Favor informar o Usuário")]
        public string Usuario { get;  set; }

        [Display(Name ="Senha")]
        [Required(ErrorMessage = "Favor informar Senha")]
        public string Senha { get;  set; }
        [Display(Name ="Confirmar Senha")]
        [Required(ErrorMessage = "Favor informar Confirma Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "Senha informada não está correta")]
        public string ConfirmaSenha { get;  set; }
        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get;  set; }
        [Display(Name ="Confirmar Email")]
        [Required(ErrorMessage = "Favor informar Confirmar Email")]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Senha informada não está correta")]

        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage ="Favor informar ativação do livro")]
        public bool Situacao { get;  set; }
        
        [Display(Name ="Situacao")]
       public string LabelSituacao { get; set; } 
        [Required(ErrorMessage ="Favor informar a imagem")]

        [Display(Name ="Imagem")]
        public HttpPostedFileBase Imagem { get;  set; }

        public List<string> ListaErros { get; set; }
        public Bibliotecaria()
        {
            ListaErros = new List<string>();
         }
        public List<SelectListItem> _liststatus { get; set; }
        public List<SelectListItem> ListStatus()
        {
            
            List<SelectListItem> myList = new List<SelectListItem>();
                var data = new[]{
                     new SelectListItem { Text = "Inativo", Value = "0" },
                    new SelectListItem { Text = "Ativo", Value = "1" }

            };
            myList = data.ToList();
            return myList;
            
        }
    }
}
