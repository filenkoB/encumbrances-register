using Domain.Interfaces.Services;
using Domain.Interfaces.Write;
using MediatR;
using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Users.Commmands
{
    public class DeclineUserRegistrationCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }
        public string Email { get; set; }
        public string Reason { get; set; }

        public DeclineUserRegistrationCommand(Guid statementId, string email, string reason)
        {
            StatementId = statementId;
            Email = email;
            Reason = reason;
        }
    }

    public class DeclineUserRegistrationCommandHandler : IRequestHandler<DeclineUserRegistrationCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly ISmtpService _smtpService;

        public DeclineUserRegistrationCommandHandler(
            IStatementWriteRepository statementWriteRepository,
            ISmtpService smtpService)
        {
            _statementWriteRepository = statementWriteRepository;
            _smtpService = smtpService;
        }
        public async Task<Unit> Handle(DeclineUserRegistrationCommand command, CancellationToken cancellationToken)
        {
            await _statementWriteRepository.UpdateStatementTouchedStatusAsync(command.StatementId);
            SendIdentificatorViaEmail(command.Email, command.Reason);
            return Unit.Value;
        }

        private void SendIdentificatorViaEmail(string destEmail, string reason)
        {
            MailMessage message = new MailMessage(_smtpService.GetSourceEmail(), destEmail);
            message.Subject = "Отримання доступу до Державного реєстру обтяжень рухомого майна";
            message.Body = "<h3>Вам було відмовлено у доступі до Державного реєстру обтяжень рухомого майна на правах користувача</h3>" +
                "<p>Причина: <i>" + reason + "</i></p>";
            message.IsBodyHtml = true;

            SmtpClient client = _smtpService.GetSmtpConnection();
            client.Send(message);
        }
    }
}
