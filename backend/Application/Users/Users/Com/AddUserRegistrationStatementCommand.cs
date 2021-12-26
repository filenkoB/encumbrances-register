using Application.Users.Users.Dtos;
using AutoMapper;
using Domain.Interfaces.Write;
using MediatR;
using MongoDB.Bson;
using System;
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
        public AddUserRegistrationStatementCommandHandler(IStatementWriteRepository statementWriteRepository)
        {
            _statementWriteRepository = statementWriteRepository;
        }

        public async Task<Unit> Handle(AddUserRegistrationStatementCommand command, CancellationToken cancellationToken)
        {
            var statementBson = command.CreateUserDto.ToBsonDocument();

            statementBson.Add(new BsonElement("IsTouched", false));
            statementBson.Add(new BsonElement("UserType", 3));
            statementBson.Add(new BsonElement("Date", DateTime.Now));
            statementBson.Add(new BsonElement("Number", await _statementWriteRepository.GetNewStatementNumber()));
            
            await _statementWriteRepository.AddStatementAsync(statementBson);

            return Unit.Value;
        }
    }
}
