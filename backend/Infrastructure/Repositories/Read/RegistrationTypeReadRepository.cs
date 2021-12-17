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
    public class RegistrationTypeReadRepository : IRegistrationTypeReadRepository
    {
        private readonly NpgsqlConnection _db;
        public RegistrationTypeReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<RegistrationType>> GetAllRegistrationTypesAsync()
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"RegistrationTypes\"";
            var result = await _db.QueryAsync<RegistrationType>(sqlQuery);
            await _db.CloseAsync();
            return result;
        }
    }
}
