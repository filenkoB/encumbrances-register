using Domain.Interfaces.Read;
using Domain.PostgreSQL.Entities;
using Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Npgsql;

namespace Infrastructure.Repositories.Read
{
    public class AlienationLimitsReadRepository : IAlienationLimitsReadRepository
    {
        private readonly NpgsqlConnection _db;
        public AlienationLimitsReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<AlienationLimit>> GetAllAlienationLimitsAsync()
        {
            var sqlQuery = "SELECT * FROM \"AlienationLimits\"";
            _db.Open();
            var result = await _db.QueryAsync<AlienationLimit>(sqlQuery);
            await _db.CloseAsync();
            return result;
        }
    }
}
