using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IStreetReadRepository
    {
        public Task<IEnumerable<Street>> GetAllCityStreetsAsync(Guid cityId);
    }
}
