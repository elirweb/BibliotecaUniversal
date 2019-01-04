using Biblioteca.Core.Domain.Validador;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using UsuarioBiblioteca.Domain.Entidades;

namespace UsuarioBiblioteca.Domain.Entidades
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
        public int Categoria { get; private set; }

        public Livro()
        {

        }

        [NotMapped]
        public ValidacaoResultado ValidacaoResultado { get; set; }

        public Livro(Guid id, string titulo, int qtd,string editora, bool ativ, string descricao, Guid idbiblio, int cat)
        {
            Id = id;
            Titulo = titulo;
            QtdPg = qtd;
            Editora = editora;
            Ativo = ativ;
            Descricao = descricao;
            IdBiblioteca = idbiblio;
            Categoria = cat;
        }
    }
}
