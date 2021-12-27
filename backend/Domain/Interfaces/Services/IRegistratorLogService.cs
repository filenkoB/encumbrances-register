using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IRegistratorLogService
    {
        public Task LogExtractGettingOperation(Guid encumbranceId, Guid statementId, Guid issuerId, string ipAddress);
        public Task LogStatementPerformOperation(Guid statementId, Guid issuerId, Guid reaId, string ipAddress);
    }
}
