using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IDistrictReadRepository
    {
        public Task<IEnumerable<District>> GetAllRegionDistrictsAsync(Guid regionId);
    }
}
