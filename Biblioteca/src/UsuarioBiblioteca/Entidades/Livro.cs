using Biblioteca.Core.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuarioBiblioteca.Entidades
{
    public class Livro
    {
        public Guid Id { get; private set; } 
        public string Titulo { get; private set; }
        public int QtdPg { get; private set; }
        public string Editora { get; private set; }
        public bool Ativo { get; private set; }
        public string Descricao { get; private set; }
        public Guid IdBiblioteca { get;  set; }
        public virtual Bibliotecaria Biblioteca { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public Livro(Livro lv)
        {
            Id = new Guid();
            Titulo = lv.Titulo;
            QtdPg = lv.QtdPg;
            Editora = lv.Editora;
            Ativo = lv.Ativo;
            Descricao = lv.Descricao;
            IdBiblioteca = lv.IdBiblioteca;
        }
    }
}
