using Biblioteca.Core.Domain.Validador;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuarioBiblioteca.Domain.Entidades
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
        public ValidacaoResultado ValidationResult { get; set; }

        public string TipoContat  { get;private set; }

        [NotMapped]
        public string tipo  { get;private set; }
        public Endereco(string bairro, int numero, string complemento, string localidade, string uf,int telefone, string tipo,int ddd, Guid id)
        {
            Id = Guid.NewGuid();
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            Localidade = localidade;
            Uf = uf;
            Telefone = new ValueObjects.Contato(telefone, tipo);
            TipoContat = tipo;
            DDD = ddd;
            IdBlioteca = id;
        }

    }
}
