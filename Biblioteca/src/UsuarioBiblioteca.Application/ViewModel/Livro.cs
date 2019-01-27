using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using UsuarioBiblioteca.Domain.Enum;

namespace UsuarioBiblioteca.Application.ViewModel
{
    public class Livro
    {
        public Guid Id { get;  set; }

        [Required(ErrorMessage ="Favor informar o Titulo")]
        public string Titulo { get;  set; }

        [Display(Name ="Qtd de Pag.")]
        [Required(ErrorMessage ="Favor informar a Qtd de Pag.")]
        public int QtdPg { get;  set; }
        [Required(ErrorMessage="Favor informar a Editora")]
        public string Editora { get;  set; }
        public bool Ativo { get;  set; }
        [Required(ErrorMessage= "Favor informar a Descrição")]
        public string Descricao { get;  set; }
        public Guid IdBiblioteca { get; set; }
        public virtual Bibliotecaria Biblioteca { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get;  set; }
        [Display(Name ="Categoria")]
        public string DescCategoria { get; set; }
        public List<string> ListaErros { get; set; }

        public List<SelectListItem> _listlv { get; set; }
       
        public Livro()
        {
            ListaErros = new List<string>();
        }
        
        public List<SelectListItem> ListCategoria()
        {

            List<SelectListItem> myCate = new List<SelectListItem>();
            var data = new[]{
                new SelectListItem { Text = Categoria.Matematica.ToString(), Value = Categoria.Matematica.ToString() },
                new SelectListItem { Text = Categoria.Portugues.ToString(), Value = Categoria.Portugues.ToString() },
                new SelectListItem { Text = Categoria.Ciencias.ToString(), Value = Categoria.Ciencias.ToString() },
                new SelectListItem { Text = Categoria.Geografia.ToString(), Value = Categoria.Geografia.ToString() },
                new SelectListItem { Text = Categoria.Ingles.ToString(), Value = Categoria.Ingles.ToString() },
                new SelectListItem { Text = Categoria.Informatica.ToString(), Value = Categoria.Informatica.ToString() },


            };
            myCate = data.ToList();
            return myCate;

        }

        public Dictionary<Guid,string> ListBiblioteca { get; set; }
      

    }
}
