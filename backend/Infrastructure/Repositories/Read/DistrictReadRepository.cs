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
    public class DistrictReadRepository : IDistrictReadRepository
    {
        private readonly NpgsqlConnection _db;
        public DistrictReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<District>> GetAllRegionDistrictsAsync(Guid regionId)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Districts\" WHERE \"RegionId\" = @regionId";
            var result = await _db.QueryAsync<District>(sqlQuery, new { regionId = regionId });
            await _db.CloseAsync();
            return result;
        }
    }
}
