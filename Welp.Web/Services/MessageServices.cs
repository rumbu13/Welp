using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Services
{

    public class MailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Domain { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; } 
    }


    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {

        private readonly IOptions<MailSettings> _settings;

        public AuthMessageSender(IOptions<MailSettings> settings)
        {
            _settings = settings;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_settings.Value.SenderName, _settings.Value.SenderAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };
            using (var smtp = new SmtpClient())
            {
                smtp.LocalDomain = _settings.Value.Domain;
                await smtp.ConnectAsync(_settings.Value.Server, _settings.Value.Port, MailKit.Security.SecureSocketOptions.Auto).ConfigureAwait(false);
                await smtp.SendAsync(emailMessage).ConfigureAwait(false);
                await smtp.DisconnectAsync(true).ConfigureAwait(false);
            }
            

        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
