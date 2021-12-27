using Application.Statements.Dtos;
using Domain.Interfaces.Write;
using MediatR;
using MongoDB.Bson;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Commands
{
    public class RegisterExtractStatementCommand : IRequest<Guid>
    {
        public AddExtractStatementDto AddExtractStatement { get; set; }
        public RegisterExtractStatementCommand(AddExtractStatementDto addExtractStatement)
        {
            AddExtractStatement = addExtractStatement;
        }
    }

    public class RegisterExtractStatementCommandHandler : IRequestHandler<RegisterExtractStatementCommand, Guid>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;

        public RegisterExtractStatementCommandHandler(IStatementWriteRepository statementWriteRepository)
        {
            _statementWriteRepository = statementWriteRepository;
        }
        public async Task<Guid> Handle(RegisterExtractStatementCommand command, CancellationToken cancellationToken)
        {
            var extractStatementBson = command.AddExtractStatement.ToBsonDocument();

            extractStatementBson["GeneralInfo"] = new GeneralInfoDto()
            {
                Number = await _statementWriteRepository.GetNewStatementNumber(),
                RegistrationDate = DateTime.Now
            }.ToBsonDocument().AsBsonValue;
            extractStatementBson["Status"] = 0;
            await _statementWriteRepository.AddStatementAsync(extractStatementBson);

            return extractStatementBson["_id"].AsGuid;
        }
    }
}
