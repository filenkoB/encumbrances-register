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
    public class RegionReadRepository : IRegionReadRepository
    {
        private readonly NpgsqlConnection _db;
        public RegionReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<Region>> GetAllCountryRegionsAsync(Guid countryId)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Regions\" WHERE \"CountryId\" = @countryId";
            var result = await _db.QueryAsync<Region>(sqlQuery, new { countryId = countryId });
            await _db.CloseAsync();
            return result;
        }
    }
}
