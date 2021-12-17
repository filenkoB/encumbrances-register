using Domain.Interfaces;
using Domain.PostgreSQL.Entities;
using Infrastructure.EF.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsersCommonWriteRepository : IUsersCommonWriteRepository
    {
        private readonly EncumbrancesRegisterDbContext _db;

        public UsersCommonWriteRepository(EncumbrancesRegisterDbContext db)
        {
            _db = db;
        }
        public async Task ChangeUserIdentificatorStatusAsync(Guid userId, bool isActive)
        {
            Identificator userIdentificator = await _db.Identificators
                    .Include(i => i.User)
                    .FirstOrDefaultAsync(i => i.User.Id == userId);

            if (userIdentificator == default)
            {
                throw new NotImplementedException();
            }

            userIdentificator.Status = isActive ? 1 : 0;
            await _db.SaveChangesAsync();
        }
    }
}
