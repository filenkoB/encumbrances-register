using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Write
{
    public interface IUserRegistratorWriteRepository
    {
        public Task UpdateRegistratorAsync(Registrator registrator);

        public Task UpdateUserAsync(User user);

        public Task<Identificator> InsertUserAsync(User user);

        public Task<Identificator> InsertRegistratorAsync(Registrator registrator);
    }
}
