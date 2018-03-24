using Biblioteca.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Entidades
{
    public class Administradores
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public ValueObjects.Email Email { get; private set; }
        public string Login { get; private set; }
        public ValueObjects.Senha Senha { get; private set; }
        [NotMapped]
        public string ConfirmaSenha { get; private set; }

        public string Grupo { get; private set; } // role de usuario
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public Administradores(Administradores ad)
        {
            Id = new Guid();
            Nome = ad.Nome;
            Email = new ValueObjects.Email(ad.Email.Endereco);
            Login = ad.Login;
            Senha = new ValueObjects.Senha(ad.Senha.CodigoSenha,ad.ConfirmaSenha);
            Grupo = "Biblioteca";
        }

    }
}
