using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsersCommonWriteRepository
    {
        public Task ChangeUserIdentificatorStatusAsync(Guid userId, Boolean isActive);
    }
}
