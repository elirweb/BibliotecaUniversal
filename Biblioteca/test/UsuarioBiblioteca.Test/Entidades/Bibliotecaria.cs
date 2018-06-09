using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Test.Entidades
{
    public class Bibliotecaria
    {
        public Guid Id { get; set; } 
        public string RazaoSocial { get;  set; }
        public string Cnpj { get;  set; }
        public string Usuario { get;  set; }
        public string Senha { get;  set; }

        public string ConfirmaSenha { get;  set; }
        public string Email { get;  set; }
        public bool Situacao { get;  set; }
        public string Imagem { get;  set; }


        public static class BibliotecariaFactory
        {
            public static Bibliotecaria Registrar(Guid id, string razaosocial, string cnpj, string usuario ,string senha, string email, bool situacao)
            {

                return new Bibliotecaria()
                {
                    Id = id,
                    RazaoSocial = razaosocial,
                    Email = email,
                    Usuario = usuario,
                    Senha = senha,
                    Situacao = situacao,
                    Cnpj = cnpj

                };
            }
        }
    }
}
