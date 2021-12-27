using Dapper;
using Domain.Interfaces.Read;
using Infrastructure.Dapper;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Read
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly NpgsqlConnection _db;
        public UserReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }
        public async Task<bool> GetIsUserHasAuthorityAsync(Guid userId)
        {
            _db.Open();
            var sqlQuery = "SELECT \"AuthorityId\" FROM \"Users\" WHERE \"Id\" = @userId";
            var result = await _db.ExecuteScalarAsync<Guid>(sqlQuery, new { userId = userId });
            await _db.CloseAsync();

            return result != default;
        }
    }
}
