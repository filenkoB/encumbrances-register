using Domain.Entities;
using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEncumbranceReadRepository
    {
        Task<IEnumerable<ShortEncumbrance>> GetEncumbrancesByFilterAsync(EncumbrancesFilter filter);
        Task<Encumbrance> GetEncumbranceByIdAsync(Guid encumbranceId);
    }
}
