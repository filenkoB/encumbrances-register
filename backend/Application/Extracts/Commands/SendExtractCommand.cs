using Application.Enumerations;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Read;
using Domain.Interfaces.Services;
using MediatR;
using MongoDB.Bson;
using System;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Extracts.Commands
{
    public class SendExtractCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid StatementId { get; set; }
        public UserType UserType { get; set; }
        public string IpAddress { get; set; }

        public SendExtractCommand(Guid statementId, UserType userType, Guid userId, string ipAddress)
        {
            StatementId = statementId;
            UserType = userType;
            UserId = userId;
            IpAddress = ipAddress;
        }
    }

    public class SendExtractCommandHandler : IRequestHandler<SendExtractCommand, Unit>
    {
        private readonly IExtractGeneratorService _extractGeneratorService;
        private readonly ISmtpService _smtpService;
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IUserCommonReadRepository _userCommonReadRepository;
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IRegistratorLogService _registratorLogService;

        public SendExtractCommandHandler(
            IExtractGeneratorService extractGeneratorService,
            ISmtpService smtpService,
            IEncumbranceReadRepository encumbranceReadRepository,
            IUserCommonReadRepository userCommonReadRepository,
            IStatementReadRepository statementReadRepository,
            IRegistratorLogService registratorLogService)
        {
            _encumbranceReadRepository = encumbranceReadRepository;
            _extractGeneratorService = extractGeneratorService;
            _userCommonReadRepository = userCommonReadRepository;
            _statementReadRepository = statementReadRepository;
            _smtpService = smtpService;
            _registratorLogService = registratorLogService;
        }

        public async Task<Unit> Handle(SendExtractCommand command, CancellationToken token)
        {
            BsonDocument extractStatement = await _statementReadRepository.GetStatementAsync(command.StatementId);

            ExtractEncumbrance extractEncumbrance = await _encumbranceReadRepository.GetExtractEncumbrance(
                extractStatement["EncumbranceId"].AsGuid    
            );
            MemoryStream mstream = new MemoryStream();
            _extractGeneratorService.GenerateExtractForEncumbrance(ref mstream, extractEncumbrance);

            Guid userId = command.UserId;
            UserType userType = command.UserType;
            var userEmail = await _userCommonReadRepository.GetUserEmailAsync(userId, userType);
            SendEmailToUser(userEmail, ref mstream);

            await _registratorLogService.LogExtractGettingOperation(
                extractStatement["EncumbranceId"].AsGuid,
                command.StatementId,
                command.UserId,
                command.IpAddress
            );

            return Unit.Value;
        }

        private void SendEmailToUser(string userEmail, ref MemoryStream mstream)
        {
            mstream.Position = 0;
            MailMessage message = new MailMessage(_smtpService.GetSourceEmail(), userEmail);
            message.Subject = "Операція отримання витягу з Державного реєстру обтяжень рухомого майна";
            message.Attachments.Add(new Attachment(mstream, "Витяг з державного реєстру обтяжень рухомого майна.pdf"));

            SmtpClient client = _smtpService.GetSmtpConnection();
            client.Send(message);
        }
    }
}
