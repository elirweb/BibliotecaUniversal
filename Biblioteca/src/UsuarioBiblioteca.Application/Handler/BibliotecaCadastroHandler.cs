using Biblioteca.Core.Infra.Email.Interfaces;

namespace UsuarioBiblioteca.Application.Handler
{
    public class BibliotecaCadastroHandler
    {
        private readonly IEnvioEmail envioemail;

        public BibliotecaCadastroHandler(IEnvioEmail env)
        {
            envioemail = env;
        }

        public void SejaBemVindo(string endereco, string nome, string assunto, string mensagem)
        {

            var email = new Biblioteca.Core.Infra.Email.Domain.Email(endereco, nome, assunto, mensagem);
            envioemail.EnviarAsync(email);
        }
    }
}
