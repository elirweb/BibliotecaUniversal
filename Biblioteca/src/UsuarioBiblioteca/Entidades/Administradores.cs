using Biblioteca.Core.Domain.Validador;
using Biblioteca.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsuarioBiblioteca.Domain.Entidades
{
    public class Administradores
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Biblioteca.Core.Domain.ValueObjects.Email Email { get; private set; }
        public string Login { get; private set; }
        public Biblioteca.Core.Domain.ValueObjects.Senha Senha { get; private set; }
        public string Grupo { get; private set; } // role de usuario

        [NotMapped]
        public string ConfirmaSenha { get; private set; }

        [NotMapped]
        public ValidacaoResultado ValidacaoResultado { get; set; }

        public Administradores(string nome, string email, string login, string senha, string confirma)
        {
            Id = new Guid();
            Nome = nome;
            Email = new Biblioteca.Core.Domain.ValueObjects.Email(email);
            Login = login;
            Senha = new Senha(senha,confirma);
            Grupo = "Biblioteca";
        }

        public Administradores(string login, string senha)
        {
            Login = login;
            Senha = new Biblioteca.Core.Domain.ValueObjects.Senha(senha);
        }
    }
}
