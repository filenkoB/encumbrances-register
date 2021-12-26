using Application.Users.Registrators.Dtos;
using Domain.Interfaces.Write;
using MediatR;
using MongoDB.Bson;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        public AddRegistratorRegistrationStatementCommandHandler(IStatementWriteRepository statementWriteRepository)
        {
            _statementWriteRepository = statementWriteRepository;
        }

        public async Task<Unit> Handle(AddRegistratorRegistrationStatementCommand command, CancellationToken cancellationToken)
        {
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
