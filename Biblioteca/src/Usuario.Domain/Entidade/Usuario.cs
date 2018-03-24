
using Biblioteca.Core.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario.Domain.Entidade
{
    public class Usuario: Base.BasePrincipal
    {
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public ValueObjects.Senha Senha { get; private set; }

        [NotMapped]
        public string ConfirmaSenha { get; private set; }
        public ValueObjects.Email Email { get; private set; }
        public ValueObjects.CPF Cpf { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public Usuario(Usuario usu)
        {
            Id = new System.Guid();
            Nome = usu.Nome;
            Login = usu.Login;
            Senha = new ValueObjects.Senha(usu.Senha.CodigoSenha,usu.ConfirmaSenha);
            Email = new ValueObjects.Email(usu.Email.Endereco);
            Cpf = new ValueObjects.CPF(usu.Cpf.Codigo);
        }         
    }
}
