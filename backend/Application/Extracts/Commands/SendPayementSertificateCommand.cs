using Application.Enumerations;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using Domain.Interfaces.Services;
using Domain.Interfaces.Write;
using Domain.PostgreSQL.Entities;
using MediatR;
using MongoDB.Bson;
using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Extracts.Commands
{
    public class SendPayementSertificateCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }
        public Guid UserId { get; set; }
        public UserType UserType { get; set; }
        public SendPayementSertificateCommand(Guid statementId, Guid userId, UserType userType)
        {
            StatementId = statementId;
            UserId = userId;
            UserType = userType;
        }
    }

    public class SendPayementSertificateCommandHandler : IRequestHandler<SendPayementSertificateCommand, Unit>
    {
        private readonly IPayementSertificateWriteRepository _payementSertificateWriteRepository;
        private readonly IReadRepository<User> _userReadRepository;
        private readonly IReadRepository<Registrator> _registratorReadRepository;
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly ISmtpService _smtpService;

        public SendPayementSertificateCommandHandler(
            IPayementSertificateWriteRepository payementSertificateWriteRepository,
            IStatementReadRepository statementReadRepository,
            IReadRepository<User> userReadRepository,
            IReadRepository<Registrator> registratorReadRepository,
            ISmtpService smtpService)
        {
            _userReadRepository = userReadRepository;
            _statementReadRepository = statementReadRepository;
            _registratorReadRepository = registratorReadRepository;
            _payementSertificateWriteRepository = payementSertificateWriteRepository;
            _smtpService = smtpService;
        }

        public async Task<Unit> Handle(SendPayementSertificateCommand command, CancellationToken cancellationToken)
        {
            var payementSertificate = new
            {
                IssuerId = command.UserId,
                StatementId = command.StatementId
            }.ToBsonDocument();
            await _payementSertificateWriteRepository.InsertAsync(payementSertificate);

            string email = String.Empty;
            switch (command.UserType)
            {
                case UserType.Registrator:
                    email = (await _registratorReadRepository.GetEntityByIdAsync(command.UserId, "Registrators")).Email;
                    break;
                case UserType.SimpleUser:
                    email = (await _userReadRepository.GetEntityByIdAsync(command.UserId, "Users")).Email;
                    break;
            }

            if (String.IsNullOrEmpty(email))
            {
                return Unit.Value;
            }
            var statementNumber = (await _statementReadRepository.GetStatementAsync(command.StatementId))["GeneralInfo"]["Number"].AsString;
            SendEmailToUser(email, statementNumber);

            return Unit.Value;

        }
        private void SendEmailToUser(string userEmail, string statementNumber)
        {
            MailMessage message = new MailMessage(_smtpService.GetSourceEmail(), userEmail);
            message.Subject = "Успішна оплата операції отримання витягу з Державного реєстру обтяжень рухомого майна";
            message.Body = $"<p><b>Номер заяви: </b> {statementNumber}</p>" +
                $"<p><b>Сума, надана до сплати: </b> 40 гривень</p>" +
                $"<p><i>Дякуємо!</i></p>";

            SmtpClient client = _smtpService.GetSmtpConnection();
            client.Send(message);
        }
    }
}
