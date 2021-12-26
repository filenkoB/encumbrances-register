using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Abstract
{
    public interface IWriteRepository<TValue>
    {
        public Task InsertAsync(TValue document);
        public Task UpdateAsync(TValue document);
        public Task DeleteAsync(Guid id);
    }
}
