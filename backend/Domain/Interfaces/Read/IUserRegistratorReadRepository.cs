using Domain.Entities;
using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRegistratorReadRepository
    {
        public Task<IEnumerable<Registrator>> GetActiveRegistratorsAsync();
        public Task<IEnumerable<RegistratorAction>> GetActiveRegistratorActionsAsync(Guid registratorId);
    }
}
