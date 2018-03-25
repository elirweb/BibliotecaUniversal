
using Biblioteca.Core.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Domain.Entidade
{
    public class Usuario: Base.BasePrincipal
    {
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public Biblioteca.Core.Domain.ValueObjects.Senha Senha { get; private set; }

        [NotMapped]
        public string ConfirmaSenha { get; private set; }
        public Biblioteca.Core.Domain.ValueObjects.Email Email { get; private set; }
        public ValueObjects.CPF Cpf { get; private set; }

        public string Grupo { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public Usuario(string nome,string login,string senha, string confirma,string email,string cpf)
        {
            Id = new System.Guid();
            Nome = nome;
            Login = login;
            Senha = new Biblioteca.Core.Domain.ValueObjects.Senha(senha,confirma);
            Email = new Biblioteca.Core.Domain.ValueObjects.Email(email);
            Cpf = new ValueObjects.CPF(cpf);
            Grupo = "Usuario";
        }         
    }
}
