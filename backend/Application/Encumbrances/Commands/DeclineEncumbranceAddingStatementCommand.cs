using Domain.Interfaces.Services;
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
        public Guid RegistratorId { get; set; }
        public string IpAddress { get; set; }

        public DeclineEncumbranceStatementCommand(Guid statementId, Guid registratorId, string ipAddress)
        {
            StatementId = statementId;
            RegistratorId = registratorId;
            IpAddress = ipAddress;
        }
    }

    public class DeclineEncumbranceStatementCommandHandler : IRequestHandler<DeclineEncumbranceStatementCommand, Unit>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IRegistratorLogService _registratorLogService;

        public DeclineEncumbranceStatementCommandHandler(
            IStatementWriteRepository statementWriteRepository,
            IRegistratorLogService registratorLogService)
        {
            _registratorLogService = registratorLogService;
            _statementWriteRepository = statementWriteRepository;
        }

        public async Task<Unit> Handle(DeclineEncumbranceStatementCommand command, CancellationToken cancellationToken)
        {
            await _statementWriteRepository.UpdateEncumbranceStatementStatus(command.StatementId, 2);
            await _registratorLogService.LogStatementPerformOperation(
                command.StatementId,
                command.RegistratorId,
                new Guid("789423fd-ebcf-402b-92e9-be83dead6109"),
                command.IpAddress
            );

            return Unit.Value;
        }
    }
}
