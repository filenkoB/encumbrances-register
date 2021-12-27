using Domain.PostgreSQL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using System;

namespace Domain.Interfaces
{
    public interface IEncumbranceReadRepository
    {
        Task<IEnumerable<Encumbrance>> GetEncumbranesAsync();
        Task<IEnumerable<Encumbrance>> GetEncumbrancesByFilterAsync(EncumbranceSelectFilter filter);
        Task<ExtractEncumbrance> GetExtractEncumbrance(Guid encumbranceId);
        Task<long> GetNextEncumbranceNumberAsync();
        Task<Encumbrance> GetEncumbranceByRegNumber(string regNumber);
    }
}
