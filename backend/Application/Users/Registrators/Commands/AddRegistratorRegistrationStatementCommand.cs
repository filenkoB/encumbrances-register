using Application.Users.Registrators.Dtos;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Write;
using Domain.PostgreSQL.Entities;
using MediatR;
using MongoDB.Bson;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Application.Users.Registrators.Commands
{
    public class AddRegistratorRegistrationStatementCommand : IRequest<Unit>
    {
        public CreateRegistratorDto CreateRegistratorDto { get; set; }
        
        public AddRegistratorRegistrationStatementCommand(CreateRegistratorDto createRegistratorDto)
        {
            CreateRegistratorDto = createRegistratorDto;
        }
    }

    public class AddRegistratorRegistrationStatementCommandHandler : IRequestHandler<AddRegistratorRegistrationStatementCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IReadRepository<Registrator> _registratorReadRepository;
        private readonly IReadRepository<PassportInfo> _passportInfoReadRepository;
        public AddRegistratorRegistrationStatementCommandHandler(
            IStatementWriteRepository statementWriteRepository,
            IReadRepository<Registrator> registratorReadRepository,
            IReadRepository<PassportInfo> passportInfoReadRepository)
        {
            _registratorReadRepository = registratorReadRepository;
            _statementWriteRepository = statementWriteRepository;
            _passportInfoReadRepository = passportInfoReadRepository;
        }

        public async Task<Unit> Handle(AddRegistratorRegistrationStatementCommand command, CancellationToken cancellationToken)
        {
            IEnumerable<Registrator> registrators = await _registratorReadRepository.GetEntitiesAsync("Registrators");
            CreateRegistratorDto dto = command.CreateRegistratorDto;
            if (registrators.Any(r => r.Email == dto.Email))
            {
                throw new RegistrationException(
                    "Реєстратор із заданою поштовою адресою вже зареєстрований у системі."
                );
            }

            IEnumerable<PassportInfo> passportInfo = await _passportInfoReadRepository.GetEntitiesByParamsAsync("PassportInfos",
                ("PassportNumber", dto.PassportInfo.PassportNumber)
            );
            if (passportInfo.Any())
            {
                throw new RegistrationException(
                    "Реєстратор із заданим номером паспорта вже зареєстрований у системі."
                );
            }

            var statementBson = command.CreateRegistratorDto.ToBsonDocument();

            statementBson.Add(new BsonElement("IsTouched", false));
            statementBson.Add(new BsonElement("UserType", 2));
            statementBson.Add(new BsonElement("Date", DateTime.Now));
            statementBson.Add(new BsonElement("Number", await _statementWriteRepository.GetNewStatementNumber()));
            
            await _statementWriteRepository.AddStatementAsync(statementBson);

            return Unit.Value;
        }
    }
}
