using Biblioteca.Core.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuarioBiblioteca.Entidades
{
    public class Bibliotecaria:Base.BasePrincipal
    {
        public string RazaoSocial { get; private set; }
        public ValueObjects.CNPJ Cnpj { get; private set; }
        public string Usuario { get; private set; }
        public ValueObjects.Senha Senha { get; private set; }

        [NotMapped]
        public string ConfirmaSenha { get; private set; }
        public ValueObjects.Email Email { get; private set; }

        [NotMapped]
        public Endereco Endereco { get; private set; }
        public bool Situacao { get; private set; }
        public string Imagem { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public Bibliotecaria(Bibliotecaria bib,Endereco endereco)
        {
           RazaoSocial = bib.RazaoSocial;
           Cnpj = new ValueObjects.CNPJ(Convert.ToString(bib.Cnpj));
           Usuario = bib.Usuario;
           Senha = new ValueObjects.Senha(bib.Senha.CodigoSenha, bib.ConfirmaSenha);
           Email = new ValueObjects.Email(bib.Email.Endereco);
           MomentoCadastro(bib.Situacao); // no momento de eu criar o cadastro posso definir se deixo ativo ou não
           Endereco = new Endereco(endereco);
           Imagem = bib.Imagem;
        }

        public void MomentoCadastro(bool situacao) {
            Situacao = situacao;
        }
    }
}
