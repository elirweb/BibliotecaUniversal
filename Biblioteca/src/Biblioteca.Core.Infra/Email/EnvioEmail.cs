using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Core.Infra.Email.Domain;
using System.Net.Mail;
using System.Net;

namespace Biblioteca.Core.Infra.Email
{
    public class EnvioEmail : Interfaces.IEnvioEmail
    {
        public async Task EnviarAsync(Domain.Email email)
        {
            // Command line argument must the the SMTP host.
            using (var client = new SmtpClient())
            {
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("seuemail@gmail.com", "*********");

                var mm = new MailMessage("donotreply@domain.com", email.Endereco, email.Assunto, email.Mensagem)
                {
                    BodyEncoding = Encoding.UTF8,
                    DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                };

                await Task.FromResult(0);
            }
        }
    }
}
