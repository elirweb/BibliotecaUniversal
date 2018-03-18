
namespace Usuario.Domain.Entidades
{
    public class Usuario: Base.BasePrincipal
    {
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public ValueObjects.Senha Senha { get; private set; }
        public string ConfirmaSenha { get; private set; }
        public ValueObjects.Email Email { get; private set; }
        public ValueObjects.CPF Cpf { get; private set; }         
    }
}
