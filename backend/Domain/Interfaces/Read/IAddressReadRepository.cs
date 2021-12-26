using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IAddressReadRepository
    {
        public Task<ComposedAddress> GetComposedAddressAsync(Guid addressId);
    }
}
