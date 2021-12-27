using Application.Users.Users.Dtos;
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

namespace Application.Users.Users.Commmands
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }

        public RegisterUserCommand(Guid statementId)
        {
            StatementId = statementId;
        }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRegistratorWriteRepository _userRegistratorWriteRepository;
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IMapper _mapper;
        private readonly ISmtpService _smtpService;

        public RegisterUserCommandHandler(
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
        public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            BsonDocument statementBson = await _statementReadRepository.GetStatementAsync(command.StatementId);
            var statementInfo = _mapper.Map<CreateUserDto>(statementBson);

            PassportInfo passportInfo = _mapper.Map<PassportInfo>(statementInfo.PassportInfo);

            var newUser = _mapper.Map<User>(statementInfo);
            newUser.RegisteredAt = DateTime.Now;
            newUser.PassportInfo = passportInfo;
            newUser.PassportInfoId = passportInfo.PassportNumber;

            Identificator identificator = await _userRegistratorWriteRepository.InsertUserAsync(newUser);
            await _statementWriteRepository.UpdateStatementTouchedStatusAsync(command.StatementId);
            SendIdentificatorViaEmail(newUser.Email, identificator);
            return Unit.Value;
        }

        private void SendIdentificatorViaEmail(string destEmail, Identificator identificator)
        {
            MailMessage message = new MailMessage(_smtpService.GetSourceEmail(), destEmail);
            message.Subject = "Отримання доступу до Державного реєстру обтяжень рухомого майна";
            message.Body = "<h3>Вам було надано доступ до Державного реєстру обтяжень рухомого майна на правах користувача</h3>" +
                "<h4>Дані для входу:</h4>" +
                "<p>Логін: <i>" + identificator.Login + "</i></p>" +
                "<p>Пароль: <i>" + identificator.Password + "</i></p>";
            message.IsBodyHtml = true;

            SmtpClient client = _smtpService.GetSmtpConnection();
            client.Send(message);
        }
    }
}
