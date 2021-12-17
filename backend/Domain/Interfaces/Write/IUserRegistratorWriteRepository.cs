using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRegistratorWriteRepository
    {
        public Task UpdateUserAsync(User user);
        public Task UpdateRegistratorAsync(Registrator registrator);

        public Task<Identificator> InsertUserAsync(User user);
        public Task<Identificator> InsertRegistratorAsync(Registrator registrator);
    }
}
