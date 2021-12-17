using Domain.Interfaces.Read;
using Domain.PostgreSQL.Entities;
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
    public class StreetReadRepository : IStreetReadRepository
    {
        private readonly NpgsqlConnection _db;
        public StreetReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<Street>> GetAllCityStreetsAsync(Guid cityId)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Streets\" WHERE \"CityId\" = @cityid";
            var result = await _db.QueryAsync<Street>(sqlQuery, new { cityid = cityId });
            await _db.CloseAsync();
            return result;
        }
    }
}
