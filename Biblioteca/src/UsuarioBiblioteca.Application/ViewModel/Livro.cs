using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Categoria Categoria { get;  set; }
        [Display(Name ="Categoria")]
        public string DescCategoria { get; set; }
        public List<string> ListaErros { get; set; }
        public Livro()
        {
            ListaErros = new List<string>();
        }

        public IEnumerable<SelectListItem> ListCategoria
        {
            get
            {
                return new[]
                {
                        new SelectListItem { Value = "2", Text = Categoria.Ciencias.ToString() },
                        new SelectListItem { Value = "2", Text = Categoria.Ciencias.ToString() },
                        new SelectListItem { Value = "2", Text = Categoria.Ciencias.ToString() },
                        new SelectListItem { Value = "2", Text = Categoria.Ciencias.ToString() },

                };
            }
        }
    }
}
