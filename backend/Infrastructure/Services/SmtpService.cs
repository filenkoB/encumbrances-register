using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpClient _client;
        private readonly string _sourceEmail;
        public SmtpService(IConfiguration configuration)
        {
            _client = new SmtpClient("smtp.gmail.com");
            _client.Credentials = new NetworkCredential(configuration["SMTP_ADDRESS"], configuration["SMTP_PASSWORD"]);
            _client.EnableSsl = true;

            _sourceEmail = configuration["SMTP_ADDRESS"];
        }
        public SmtpClient GetSmtpConnection()
        {
            return _client;
        }
        public string GetSourceEmail()
        {
            return _sourceEmail;
        }
    }
}
