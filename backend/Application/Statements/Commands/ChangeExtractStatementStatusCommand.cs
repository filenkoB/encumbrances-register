using Domain.Interfaces.Write;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Commands
{
    public class ChangeExtractStatementStatusCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }
        public int Status { get; set; }

        public ChangeExtractStatementStatusCommand(Guid statementId, int status)
        {
            StatementId = statementId;
            Status = status;
        }
    }

    public class ChangeExtractStatementStatusCommandHandler : IRequestHandler<ChangeExtractStatementStatusCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;

        public ChangeExtractStatementStatusCommandHandler(IStatementWriteRepository statementWriteRepository)
        {
            _statementWriteRepository = statementWriteRepository;
        }
        public async Task<Unit> Handle(ChangeExtractStatementStatusCommand command, CancellationToken cancellationToken)
        {
            await _statementWriteRepository.UpdateEncumbranceStatementStatus(command.StatementId, command.Status);

            return Unit.Value;
        }
    }
}
