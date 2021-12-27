using System.Net.Mail;

namespace Domain.Interfaces.Services
{
    public interface ISmtpService
    {
        public string GetSourceEmail();
        public SmtpClient GetSmtpConnection();
    }
}
