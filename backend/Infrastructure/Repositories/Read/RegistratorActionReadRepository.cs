using Dapper;
using Domain.Entities;
using Domain.Interfaces.Read;
using Infrastructure.Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Read
{
    public class RegistratorActionReadRepository : IRegistratorActionReadRepository
    {
        private readonly NpgsqlConnection _db;
        public RegistratorActionReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }
        public async Task<IEnumerable<RegistratorAction>> GetRegistratorActionsAsync(Guid registratorId)
        {
            var sqlQuery = "SELECT * FROM \"GetRegistratorActions\"(@registratorId)";
            _db.Open();
            var result = await _db.QueryAsync<RegistratorAction>(sqlQuery, new { registratorId = registratorId });
            await _db.CloseAsync();

            return result;
        }
    }
}
