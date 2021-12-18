using Application.Enumerations;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserCommonReadRepository
    {
        public Task<UserType> GetUserTypeByIdentificatorAsync(string login);
        public Task<Guid> GetUserByCredentialsAsync(string login, string password);
    }
}
