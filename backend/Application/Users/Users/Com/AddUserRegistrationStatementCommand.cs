using Application.Users.Users.Dtos;
using Domain.Exceptions;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Write;
using Domain.PostgreSQL.Entities;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Users.Com
{
    public class AddUserRegistrationStatementCommand : IRequest<Unit>
    {
        public CreateUserDto CreateUserDto { get; set; }

        public AddUserRegistrationStatementCommand(CreateUserDto createUserDto)
        {
            CreateUserDto = createUserDto;
        }
    }

    public class AddUserRegistrationStatementCommandHandler : IRequestHandler<AddUserRegistrationStatementCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IReadRepository<User> _userReadRepository;
        private readonly IReadRepository<PassportInfo> _passportInfoReadRepository;
        public AddUserRegistrationStatementCommandHandler(
            IStatementWriteRepository statementWriteRepository,
            IReadRepository<PassportInfo> passportInfoReadRepository,
            IReadRepository<User> userReadRepository)
        {
            _userReadRepository = userReadRepository;
            _passportInfoReadRepository = passportInfoReadRepository;
            _statementWriteRepository = statementWriteRepository;
        }

        public async Task<Unit> Handle(AddUserRegistrationStatementCommand command, CancellationToken cancellationToken)
        {
            IEnumerable<User> registrators = await _userReadRepository.GetEntitiesAsync("Users");
            CreateUserDto dto = command.CreateUserDto;
            if (registrators.Any(r => r.Email == dto.Email))
            {
                throw new RegistrationException(
                    "Користувач із заданою поштовою адресою вже зареєстрований у системі."
                );
            }
            else if (registrators.Any(r => r.TaxpayerAccountCardNumber == dto.TaxpayerAccountCardNumber))
            {
                throw new RegistrationException(
                    "Користувач із заданим номером карти платника податків вже зареєстрований у системі."
                );
            }

            IEnumerable<PassportInfo> passportInfo = await _passportInfoReadRepository.GetEntitiesByParamsAsync("PassportInfos",
                ("PassportNumber", dto.PassportInfo.PassportNumber)
            );
            if (passportInfo.Any())
            {
                throw new RegistrationException(
                    "Користувач із заданим номером паспорта вже зареєстрований у системі."
                );
            }

            dto.BirthDate = dto.BirthDate.AddHours(2);
            var statementBson = dto.ToBsonDocument();

            statementBson.Add(new BsonElement("IsTouched", false));
            statementBson.Add(new BsonElement("UserType", 3));
            statementBson.Add(new BsonElement("Date", DateTime.Now.AddHours(2)));
            statementBson.Add(new BsonElement("Number", await _statementWriteRepository.GetNewStatementNumber()));
            
            await _statementWriteRepository.AddStatementAsync(statementBson);

            return Unit.Value;
        }
    }
}
