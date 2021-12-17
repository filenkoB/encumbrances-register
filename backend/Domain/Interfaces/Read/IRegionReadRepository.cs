using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IRegionReadRepository
    {
        public Task<IEnumerable<Region>> GetAllCountryRegionsAsync(Guid countryId);
    }
}
