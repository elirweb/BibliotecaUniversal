using Biblioteca.Core.Domain.Validador;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Domain.Entidade
{
    public class EnderecoUsuario : Base.BasePrincipal
    {
        public string Localidade { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }

        public Guid IdUsuario { get; set; }
        public virtual Usuario Usuario { get; private set; }

        [NotMapped]
        public ValidacaoResultado ValidationResult { get; set; }
        public EnderecoUsuario(string bairro, int numero, string localidade,string uf,Guid idusuario,string cidade)
        {
            Id = Guid.NewGuid();
            Bairro = bairro;
            Numero = numero;
            Localidade = localidade;
            Uf = uf;
            IdUsuario = idusuario;
            Cidade = cidade;
        }

        public EnderecoUsuario()
        {
            IdUsuario = new Usuario().Id;
        }
    }
}
