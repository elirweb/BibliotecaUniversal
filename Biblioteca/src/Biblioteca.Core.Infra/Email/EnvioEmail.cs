using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

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
                client.Credentials = new NetworkCredential("seuemail@gmail.com", "********");

                var mm = new MailMessage("elirweb@gmail.com", email.Endereco, email.Assunto, email.Mensagem)
                {
                    Priority = MailPriority.Normal,
                    IsBodyHtml = true,
                    DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                };
                client.Send(mm);
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(email.Mensagem, null, MediaTypeNames.Text.Html);
                mm.AlternateViews.Add(av1);
                await Task.FromResult(0);
            }
        }
    }
}