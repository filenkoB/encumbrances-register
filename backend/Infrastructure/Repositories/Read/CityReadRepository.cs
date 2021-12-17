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
    public class CityReadRepository : ICityReadRepository
    {
        private readonly NpgsqlConnection _db;
        public CityReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<City>> GetAllDistrictCitiesAsync(Guid districtId)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Cities\" WHERE \"DistrictId\" = @districtId";
            var result = await _db.QueryAsync<City>(sqlQuery, new { districtId = districtId });
            await _db.CloseAsync();
            return result;
        }
    }
}
