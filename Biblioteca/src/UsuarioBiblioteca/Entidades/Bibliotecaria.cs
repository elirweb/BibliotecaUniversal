using Biblioteca.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuarioBiblioteca.Entidades
{
    public class Bibliotecaria:Base.BasePrincipal
    {
        private string cnpj;
        private string senha;
        private string email;
        private bool v;

        public string RazaoSocial { get; private set; }
        public ValueObjects.CNPJ Cnpj { get; private set; }
        public string Usuario { get; private set; }
        public ValueObjects.Senha Senha { get; private set; }

        [NotMapped]
        public string ConfirmaSenha { get; private set; }
        public ValueObjects.Email Email { get; private set; }

        public bool Situacao { get; private set; }
        public string Imagem { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public ICollection<Livro> Livro { get; set; }
        

        public Bibliotecaria(string razaoSocial, string cnpj, string usuario, string senha, string confirmasenha, string email, bool situacao, string imagem)
        {
            Id = Guid.NewGuid();
            RazaoSocial = razaoSocial;
            Cnpj = new ValueObjects.CNPJ(Convert.ToString(cnpj));
            Usuario = usuario;
            Senha = new ValueObjects.Senha(senha, confirmasenha);
            Email = new ValueObjects.Email(email);
            MomentoCadastro(situacao); // no momento de eu criar o cadastro posso definir se deixo ativo ou não
            Imagem = imagem;
        }

        public void MomentoCadastro(bool situacao) {
            Situacao = situacao;
        }
    }
}
