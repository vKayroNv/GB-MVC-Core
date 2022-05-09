using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using Razor.Templating.Core;

namespace AbstractCompany.Services
{
    public class EmailService : IEmailService
    {
        private SmtpClient _client = null!;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task Start()
        {
            _client = new();

            await _client.ConnectAsync("smtp.abstractcompany.com", 465, true);
            await _client.AuthenticateAsync("admin@abstractcompany.com", "password");

            _logger.LogInformation("Установлено соединение с SMTP-сервером");
        }

        public async Task Stop()
        {
            await _client.DisconnectAsync(true);

            _logger.LogInformation("Закрыто соединение с SMTP-сервером");
        }

        public async Task SendConfirmationEmailAsync(string email, string callbackUrl)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("AbstractCompany", "admin@abstractcompany.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Подтверждение почты";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = await RazorTemplateEngine.RenderAsync("MailTemplates/Confirmation.cshtml", callbackUrl)
            };

            await Start();

            await _client.SendAsync(emailMessage);
            _logger.LogInformation("Отправлено сообщение для подтверждения почты", email);

            await Stop();
        }

        public async Task SendNotification(string email)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("AbstractCompany", "admin@abstractcompany.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Подтверждение почты";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = await RazorTemplateEngine.RenderAsync("MailTemplates/Notification.cshtml")
            };

            await _client.SendAsync(emailMessage);
            _logger.LogInformation("Отправлено уведомление", email);
        }


    }
}