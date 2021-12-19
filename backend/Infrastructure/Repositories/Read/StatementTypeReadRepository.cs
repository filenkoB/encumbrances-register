using Dapper;
using Domain.Interfaces.Read;
using Infrastructure.Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using entities = Domain.Entities.PostgreSQL;

namespace Infrastructure.Repositories.Read
{
    public class StatementTypeReadRepository : IStatementTypeReadRepository
    {
        private readonly NpgsqlConnection _db;
        public StatementTypeReadRepository(PostgresConnectionFactory postgreConnectionFactory)
        {
            _db = postgreConnectionFactory.Connection;
        }

        public async Task<string> GetTypeNameAsync(Guid typeId)
        {
            _db.Open();
            var sqlQuery = "SELECT \"Name\" FROM \"StatementTypes\" WHERE \"Id\" = @typeId";
            var result = await _db.QueryFirstAsync<string>(sqlQuery, new { typeId = typeId });
            await _db.CloseAsync();

            return result;
        }

        public async Task<IEnumerable<entities.StatementType>> GetAllStatementTypesAsync()
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"StatementTypes\"";
            var result = await _db.QueryAsync<entities.StatementType>(sqlQuery);
            await _db.CloseAsync();

            return result;
        }
    }
}
