using Domain.Entities;
using Domain.Interfaces.Read;
using Infrastructure.Dapper;
using Npgsql;
using System;
using Dapper;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Read
{
    public class AddressReadRepository : IAddressReadRepository
    {
        private readonly NpgsqlConnection _db;
        public AddressReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }
        public async Task<ComposedAddress> GetComposedAddressAsync(Guid addressId)
        {
            var sqlQuery = "SELECT * FROM \"GetComposedAddress\"(@addressId)";
            _db.Open();
            var result = await _db.QueryFirstAsync<ComposedAddress>(sqlQuery, new { addressId = addressId });
            await _db.CloseAsync();

            return result;
        }
    }
}
