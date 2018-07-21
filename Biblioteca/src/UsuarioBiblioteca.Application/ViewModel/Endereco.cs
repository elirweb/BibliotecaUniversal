using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Endereco
    {
        public Guid Id { get; set; }
        [Display(Name ="Tipo de Contato")]
        [Required(ErrorMessage ="Favor informar o Contato")]
        public string tipo { get; set; }
        public List<SelectListItem> _listp { get; set; }
        public List<SelectListItem> ListTipos()
        {

            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                     new SelectListItem { Text = "Celular", Value = "Celular" },
                    new SelectListItem { Text = "Telefone", Value = "Telefone" }

            };
            myList = data.ToList();
            return myList;

        }

        [Display(Name ="Bairro")]
        [Required(ErrorMessage ="Favor informar o Bairro")]
        public string Bairro { get;  set; }
        [Display(Name ="Cidade")]
        [Required(ErrorMessage ="Favor informar a Cidade")]
        public string Cidade { get; set; }
        [Display(Name ="Numero")]
        [Required(ErrorMessage ="Favor informar o numero")]
        public int Numero { get;  set; }
        [Display(Name ="Complemento")]
       
        public string Complemento { get;  set; }
        [Display(Name ="Localidade")]
        [Required(ErrorMessage ="Favor informar a Localidade")]
        public string Localidade { get;  set; }
        [Display(Name ="UF")]
        [Required(ErrorMessage ="Favor informar o UF")]
        public string Uf { get;  set; }
        [Display(Name ="DDD")]
        [Required(ErrorMessage ="Favor informar o DDD")]
        public int DDD { get;  set; }
        [Display(Name ="Telefone")]
        [Required(ErrorMessage ="Favor informar o Telefone")]
        public string Telefone { get;  set; }
        public Bibliotecaria Bibliotecaria { get; set; }
        public string Error { get; set; }
        public Endereco()
        {
            Bibliotecaria = new Bibliotecaria();
        }
    }
}
