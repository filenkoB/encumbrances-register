using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.PostgreSQL;

namespace Domain.Interfaces.Read
{
    public interface IStatementTypeReadRepository
    {
        public Task<string> GetTypeNameAsync(Guid typeId);
        public Task<IEnumerable<StatementType>> GetAllStatementTypesAsync();
    }
}
