
using Biblioteca.Core.Domain.Validation;
using System;

namespace UsuarioBiblioteca.Entidades
{
    public class Bibliotecaria:Base.BasePrincipal
    {
        public string RazaoSocial { get; private set; }
        public ValueObjects.CNPJ Cnpj { get; private set; }
        public string Usuario { get; private set; }
        public ValueObjects.Senha Senha { get; private set; }
        //[NotMapped]
        public string ConfirmaSenha { get; private set; }
        public ValueObjects.Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Situacao { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public Bibliotecaria(Bibliotecaria bib,Endereco endereco)
        {
           RazaoSocial = bib.RazaoSocial;
           Cnpj = new ValueObjects.CNPJ(Convert.ToString(bib.Cnpj));
           Usuario = bib.Usuario;
           Senha = new ValueObjects.Senha(bib.Senha.CodigoSenha, bib.ConfirmaSenha);
           Email = new ValueObjects.Email(bib.Email.Endereco);
           Situacao = true;
           Endereco = new Endereco(endereco);
        }

        
    }
}
