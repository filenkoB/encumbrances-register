using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface ICityReadRepository
    {
        public Task<IEnumerable<City>> GetAllDistrictCitiesAsync(Guid districtId);
    }
}
