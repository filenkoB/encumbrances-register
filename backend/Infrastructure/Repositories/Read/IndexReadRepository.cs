using Domain.Interfaces.Read;
using Infrastructure.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System;
using System.Data.SqlClient;
using Npgsql;

namespace Infrastructure.Repositories.Read
{
    public class IndexReadRepository : IIndexReadRepository
    {
        private readonly NpgsqlConnection _db;
        public IndexReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<string>> GetAllCityIndicesAsync(Guid cityId)
        {
            _db.Open();
            var sqlQuery = "SELECT \"IndexCode\" FROM \"Indices\" WHERE \"CityId\" = @cityId";
            var result = await _db.QueryAsync<string>(sqlQuery, new { cityId = cityId });
            await _db.CloseAsync();
            return result;
        }
    }
}
