using Biblioteca.Core.Domain.Validation;
using System;

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
        public ValueObjects.Contato Telefone { get; private set; }
        public Guid IdBlioteca { get; private set; }
        public virtual Bibliotecaria Biblioteca { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Endereco(Endereco end)
        {
            Id = new Guid();
            Bairro = end.Bairro;
            Numero = end.Numero;
            Complemento = end.Complemento;
            Localidade = end.Localidade;
            Uf = end.Uf;
            Telefone = new ValueObjects.Contato(Convert.ToInt32(end.Telefone));
            IdBlioteca = end.Biblioteca.Id;
        }

    }
}
