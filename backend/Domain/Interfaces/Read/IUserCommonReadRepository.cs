using Application.Enumerations;
using Domain.Entities;
using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserCommonReadRepository
    {
        public Task<UserType> GetUserTypeByIdentificatorAsync(string login);
    }
}
