using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IIndexReadRepository
    {
        public Task<IEnumerable<string>> GetAllCityIndicesAsync(Guid cityId);
    }
}
