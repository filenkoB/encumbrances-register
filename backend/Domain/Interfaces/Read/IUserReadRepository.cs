using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IUserReadRepository
    {
        public Task<bool> GetIsUserHasAuthorityAsync(Guid userId);
    }
}
