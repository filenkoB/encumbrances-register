using Domain.Interfaces.Abstract;
using Domain.Interfaces.Services;
using Domain.PostgreSQL.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RegistratorLogService : IRegistratorLogService
    {
        private readonly IWriteRepository<ExtractGettingActionsHistory> _egahWriteRepository;
        private readonly IWriteRepository<RegistratorEncumbranceActionsHistory> _reahWriteRepository;

        public RegistratorLogService(
            IWriteRepository<ExtractGettingActionsHistory> egahWriteRepository,
            IWriteRepository<RegistratorEncumbranceActionsHistory> reahWriteRepository)
        {
            _egahWriteRepository = egahWriteRepository;
            _reahWriteRepository = reahWriteRepository;
        }
        public async Task LogExtractGettingOperation(Guid encumbranceId, Guid issuerId)
        {
            var egah = new ExtractGettingActionsHistory()
            {
                Date = DateTime.Now,
                EncumbranceId = encumbranceId,
                IssuerId = issuerId
            };
            await _egahWriteRepository.InsertAsync(egah);

        }

        public async Task LogStatementPerformOperation(Guid statementId, Guid issuerId, Guid reatId, string ipAddress)
        {
            var reah = new RegistratorEncumbranceActionsHistory()
            {
                Date = DateTime.Now,
                RegistratorActionTypeId = reatId,
                RegistratorId = issuerId,
                StatementId = statementId,
                IpAddress = ipAddress
            };
            await _reahWriteRepository.InsertAsync(reah);
        }
    }
}
