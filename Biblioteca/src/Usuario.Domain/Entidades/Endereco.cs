using Biblioteca.Core.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Domain.Entidades
{
    public class Endereco : Base.BasePrincipal
    {
        public string Localidade { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }

        public Guid IdUsuario { get; set; }
        public virtual Usuario Usuario { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public Endereco(Endereco end)
        {
            Bairro = end.Bairro;
            Numero = end.Numero;
            Localidade = end.Localidade;
            Uf = end.Uf;
            IdUsuario = end.IdUsuario;

        }
    }
}
