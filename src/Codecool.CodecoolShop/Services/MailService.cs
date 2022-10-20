using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Settings;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Codecool.CodecoolShop.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync()
        {
            // TODO add the request details (subject, toemail, body) stuff from the backend order object
            // Add hardcoded stuff for email data:
            // formData.append("ToEmail", "gergely.kamaras@gmail.com");
            // formData.append("Subject", "Trollolo");
            // formData.append("Body", "Jolan");

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse("gergely.kamaras@gmail.com"));
            email.Subject = "Trololo";
            var builder = new BodyBuilder();
            
            builder.HtmlBody = "hali";
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
