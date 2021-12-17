using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using entities = Domain.PostgreSQL.Entities;

namespace Domain.Interfaces.Read
{
    public interface IIndexReadRepository
    {
        public Task<IEnumerable<entities.Index>> GetAllCityIndicesAsync(Guid cityId);
    }
}
