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

        public Enum.Categoria Categoria { get; private set; } 

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public Livro(string titulo, int qtd,string editora, bool ativ, string descricao, Guid id, Enum.Categoria cat)
        {
            Id = new Guid();
            Titulo = titulo;
            QtdPg = qtd;
            Editora = editora;
            Ativo = ativ;
            Descricao = descricao;
            IdBiblioteca = id;
            Categoria = cat;
        }
    }
}
