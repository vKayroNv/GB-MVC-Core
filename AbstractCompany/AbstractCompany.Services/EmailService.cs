using MailKit.Net.Smtp;
using MimeKit;

namespace AbstractCompany.Services
{
    public class EmailService
    {
        public async Task SendConfirmationEmailAsync(string email, string callbackUrl)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("AbstractCompany", "admin@abstractcompany.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Потверждение почты";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<p>Для потверждения почты перейдите по ссылке:</p><p><a href={callbackUrl}>Потвердить</a></p>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.abstractcompany.com", 465, true);
                await client.AuthenticateAsync("admin@abstractcompany.com", "password");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}