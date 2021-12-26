using Domain.Interfaces.Write;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Encumbrances.Commands
{
    public class DeclineEncumbranceStatementCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }

        public DeclineEncumbranceStatementCommand(Guid statementId)
        {
            StatementId = statementId;
        }
    }

    public class DeclineEncumbranceStatementCommandHandler : IRequestHandler<DeclineEncumbranceStatementCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;

        public DeclineEncumbranceStatementCommandHandler(IStatementWriteRepository statementWriteRepository)
        {
            _statementWriteRepository = statementWriteRepository;
        }

        public async Task<Unit> Handle(DeclineEncumbranceStatementCommand command, CancellationToken cancellationToken)
        {
            await _statementWriteRepository.UpdateEncumbranceStatementStatus(command.StatementId, 2);

            return Unit.Value;
        }
    }
}
