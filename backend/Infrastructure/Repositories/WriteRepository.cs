using Domain.Interfaces.Abstract;
using Infrastructure.EF.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class WriteRepository<TValue> : IWriteRepository<TValue> where TValue : class
    {
        private readonly EncumbrancesRegisterDbContext _db;

        public WriteRepository(EncumbrancesRegisterDbContext db)
        {
            _db = db;
        }
        public async Task DeleteAsync(Guid id)
        {
            var document = await _db.FindAsync<TValue>(id);

            _db.Remove<TValue>(document);
            await _db.SaveChangesAsync();
        }

        public async Task InsertAsync(TValue document)
        {
            await _db.AddAsync<TValue>(document);
            await _db.SaveChangesAsync();
            _db.Entry<TValue>(document).State = EntityState.Detached;
        }

        public async Task UpdateAsync(TValue document)
        {
            _db.Update<TValue>(document);
            await _db.SaveChangesAsync();
            _db.Entry<TValue>(document).State = EntityState.Detached;
        }
    }
}
