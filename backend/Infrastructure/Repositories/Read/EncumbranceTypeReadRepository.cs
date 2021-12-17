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
    public class EncumbranceTypeReadRepository : IEncumbranceTypeReadRepository
    {
        private readonly NpgsqlConnection _db;
        public EncumbranceTypeReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<EncumbranceType>> GetAllEncumbranceTypesAsync()
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"EncumbranceTypes\"";
            var result = await _db.QueryAsync<EncumbranceType>(sqlQuery);
            await _db.CloseAsync();
            return result;
        }
    }
}