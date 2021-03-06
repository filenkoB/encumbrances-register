using Application.Users.Registrators.Dtos;
using AutoMapper;
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

namespace Application.Users.Registrators.Commands
{
    public class RegisterRegistratorCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }

        public RegisterRegistratorCommand(Guid statementId)
        {
            StatementId = statementId;
        }
    }

    public class RegisterRegistratorCommandHandler : IRequestHandler<RegisterRegistratorCommand, Unit>
    {
        private readonly IUserRegistratorWriteRepository _userRegistratorWriteRepository;
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IMapper _mapper;
        private readonly ISmtpService _smtpService;

        public RegisterRegistratorCommandHandler(
            IUserRegistratorWriteRepository userRegistratorWriteRepository,
            IStatementReadRepository statementReadRepository,
            IStatementWriteRepository statementWriteRepository,
            ISmtpService smtpService,
            IMapper mapper)
        {
            _userRegistratorWriteRepository = userRegistratorWriteRepository;
            _statementReadRepository = statementReadRepository;
            _statementWriteRepository = statementWriteRepository;
            _mapper = mapper;
            _smtpService = smtpService;
        }
        public async Task<Unit> Handle(RegisterRegistratorCommand command, CancellationToken cancellationToken)
        {
            BsonDocument statementBson = await _statementReadRepository.GetStatementAsync(command.StatementId);
            var statementInfo = _mapper.Map<CreateRegistratorDto>(statementBson);

            PassportInfo passportInfo = _mapper.Map<PassportInfo>(statementInfo.PassportInfo);

            var newRegistrator = _mapper.Map<Registrator>(statementInfo);
            newRegistrator.RegisteredAt = DateTime.Now;
            newRegistrator.PassportInfo = passportInfo;
            newRegistrator.PassportInfoId = passportInfo.PassportNumber;

            Identificator identificator = await _userRegistratorWriteRepository.InsertRegistratorAsync(newRegistrator);
            await _statementWriteRepository.UpdateStatementTouchedStatusAsync(command.StatementId);
            SendIdentificatorViaEmail(newRegistrator.Email, identificator);
            return Unit.Value;
        }

        private void SendIdentificatorViaEmail(string destEmail, Identificator identificator)
        {
            MailMessage message = new MailMessage(_smtpService.GetSourceEmail(), destEmail);
            message.Subject = "Отримання доступу до Державного реєстру обтяжень рухомого майна";
            message.Body = "<h3>Вам було надано доступ до Державного реєстру обтяжень рухомого майна на правах реєстратора</h3>" +
                "<h4>Дані для входу:</h4>" +
                "<p>Логін: <i>" + identificator.Login + "</i></p>" +
                "<p>Пароль: <i>" + identificator.Password + "</i></p>";
            message.IsBodyHtml = true;

            SmtpClient client = _smtpService.GetSmtpConnection();
            client.Send(message);
        }
    }
}
