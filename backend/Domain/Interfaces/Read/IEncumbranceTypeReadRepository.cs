using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IEncumbranceTypeReadRepository
    {
        public Task<IEnumerable<EncumbranceType>> GetAllEncumbranceTypesAsync();
    }
}
