using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Test.Entidade
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get;  set; }
        public string Login { get;  set; }
        public string Senha { get;  set; }
        public string ConfirmaSenha { get;  set; }
        public string Email { get;  set; }
        public string Cpf { get;  set; }
        public string Grupo { get;  set; }


        public static class UsuarioFactory
        {
            public static Usuario NovoUsuario(Guid id, string nome,  string email, string senha)
            {

                return new Usuario()
                {
                    IdUsuario = id,
                    Nome = nome,
                    Email = email,
                    Senha = senha
                };
            }
        }
    }
}
