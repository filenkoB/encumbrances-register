using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IRegistratorActionReadRepository
    {
        public Task<IEnumerable<RegistratorAction>> GetRegistratorActionsAsync(Guid registratorId);
    }
}
