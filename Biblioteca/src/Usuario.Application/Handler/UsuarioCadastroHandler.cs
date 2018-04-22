using Biblioteca.Core.Domain.ValueObjects;
using Biblioteca.Core.Infra.Email.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Application.Handler
{
    public class UsuarioCadastroHandler
    {
        private readonly IEnvioEmail envioemail;
        public UsuarioCadastroHandler(IEnvioEmail env)
        {
            envioemail = env;
        }

        public void SejaBemVindo(string endereco, string nome,string assunto, string mensagem) {

            var email = new Biblioteca.Core.Infra.Email.Domain.Email(endereco, nome, assunto, mensagem);
            envioemail.EnviarAsync(email);
        }

        public void RecuperSenha(string endereco, string nome, string assunto, string mensagem) {

            var email = new Biblioteca.Core.Infra.Email.Domain.Email(endereco, nome, assunto, mensagem);
            envioemail.EnviarAsync(email);

        }
    }
}
