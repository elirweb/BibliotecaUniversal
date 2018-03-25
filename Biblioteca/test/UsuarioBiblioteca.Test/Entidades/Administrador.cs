using System;

namespace UsuarioBiblioteca.Test.Entidades
{
    public class Administrador
    {
        public Guid Id { get; private set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Login { get;  set; }
        public string Senha { get;  set; }
        public string ConfirmaSenha { get;  set; }
        public string Grupo { get;  set; } // role de usuario

    }
}
