using Domain.PostgreSQL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface ICurrencyTypeReadRepository
    {
        public Task<IEnumerable<CurrencyType>> GetAllCurrencyTypesAsync();
    }
}
