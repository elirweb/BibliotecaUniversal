using Biblioteca.Core.Domain.Validador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UsuarioBiblioteca.Domain.Entidades
{
    public class Bibliotecaria:Base.BasePrincipal
    {
        
        public string RazaoSocial { get; private set; }
        public ValueObjects.CNPJ Cnpj { get; private set; }
        public string Usuario { get; private set; }
        public Biblioteca.Core.Domain.ValueObjects.Senha Senha { get; private set; }

        [NotMapped]
        public string ConfirmaSenha { get; private set; }
        public Biblioteca.Core.Domain.ValueObjects.Email Email { get; private set; }

        public bool Situacao { get; private set; }
        public string Imagem { get; private set; }

        [NotMapped]
        public ValidacaoResultado ValidacaoResultado { get; set; }

        [NotMapped]
        private IList<Livro> _lista;
        public ICollection<Livro> Livro {
            get {
                
                    return _lista?.ToArray();
            } }

        public Bibliotecaria()
        {

        }
        public Bibliotecaria(string razaoSocial, string cnpj, string usuario, string senha, string confirmasenha, string email, bool situacao,string imagem, Guid id)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Cnpj = new ValueObjects.CNPJ(cnpj);
            Usuario = usuario;
            Senha = new Biblioteca.Core.Domain.ValueObjects.Senha(senha, confirmasenha);
            Email = new Biblioteca.Core.Domain.ValueObjects.Email(email);
            MomentoCadastro(situacao); // no momento de eu criar o cadastro posso definir se deixo ativo ou não
           Imagem = imagem;
            DtCadastro = DateTime.Now;
            HoraCadastro = TimeSpan.Parse(DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes);
        }

        public Bibliotecaria(Guid id, string razaoSocial)
        {
            Id = id;
            RazaoSocial = razaoSocial;
        }

        public void MomentoCadastro(bool situacao) {
            Situacao = situacao;
        }
        public void AdicionarLivro(Livro lv)
        {
            _lista.Add(lv);
        }


    }
}
