using Application.Statements.Dtos;
using Domain.Interfaces.Write;
using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Commands
{
    public class RegisterExtractStatementCommand : IRequest<Unit>
    {
        public AddExtractStatementDto AddExtractStatement { get; set; }
        public RegisterExtractStatementCommand(AddExtractStatementDto addExtractStatement)
        {
            AddExtractStatement = addExtractStatement;
        }
    }

    public class RegisterExtractStatementCommandHandler : IRequestHandler<RegisterExtractStatementCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;

        public RegisterExtractStatementCommandHandler(IStatementWriteRepository statementWriteRepository)
        {
            _statementWriteRepository = statementWriteRepository;
        }
        public async Task<Unit> Handle(RegisterExtractStatementCommand command, CancellationToken cancellationToken)
        {
            var extractStatementBson = command.AddExtractStatement.ToBsonDocument();
            extractStatementBson["Status"] = 0;
            await _statementWriteRepository.AddStatementAsync(extractStatementBson);

            return Unit.Value;
        }
    }
}
