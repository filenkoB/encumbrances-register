using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Abstract
{
    public interface IReadRepository<TValue>
    {
        public Task<IEnumerable<TValue>> GetEntitiesAsync(string tableName);
        public Task<TValue> GetEntityByIdAsync(Guid entityId, string tableName);
        public Task<IEnumerable<TValue>> GetEntitiesByParamsAsync(string tableName, params (string name, object value)[] parameters);
    }
}
