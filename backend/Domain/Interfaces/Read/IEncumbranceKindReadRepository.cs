using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IEncumbranceKindReadRepository
    {
        public Task<IEnumerable<EncumbranceKind>> GetAllEncumbranceKindsAsync();
    }
}
