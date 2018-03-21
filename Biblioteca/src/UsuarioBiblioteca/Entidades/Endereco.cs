using Biblioteca.Core.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuarioBiblioteca.Entidades
{
    public class Endereco
    {
        public Guid Id { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
        public int DDD { get; private set; }
        public ValueObjects.Contato Telefone { get; private set; }
        public Guid IdBlioteca { get; private set; }
        public virtual Bibliotecaria Biblioteca { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public string TipoContat  { get;private set; }

        [NotMapped]
        public string tipo  { get;private set; }
        public Endereco(Endereco end)
        {
            Bairro = end.Bairro;
            Numero = end.Numero;
            Complemento = end.Complemento;
            Localidade = end.Localidade;
            Uf = end.Uf;
            Telefone = new ValueObjects.Contato(Convert.ToInt32(end.Telefone), tipo);
            TipoContat = tipo;
            DDD = end.DDD;
            IdBlioteca = end.Biblioteca.Id;
        }

    }
}
