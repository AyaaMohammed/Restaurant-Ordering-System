using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using Restaurant.Core.Interfaces;
using Restaurant.Core.Settings;

namespace Restaurant.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.FromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.MailServer, _settings.MailPort, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.FromEmail, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
