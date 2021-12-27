using Dapper;
using Domain.Interfaces.Abstract;
using Infrastructure.Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReadRepository<TValue> : IReadRepository<TValue> where TValue : class
    {
        private readonly NpgsqlConnection _db;

        public ReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }

        public async Task<IEnumerable<TValue>> GetEntitiesAsync(string tableName)
        {
            var sqlQuery = $"SELECT * FROM \"{tableName}\"";
            _db.Open();
            var result = await _db.QueryAsync<TValue>(sqlQuery);
            await _db.CloseAsync();

            return result;
        }

        public async Task<IEnumerable<TValue>> GetEntitiesByParamsAsync(string tableName, params (string name, object value)[] parameters)
        {
            StringBuilder sqlSb = new StringBuilder($"SELECT * FROM \"{tableName}\" ");
            var paramsObject = new ExpandoObject();
            if (parameters.Length != 0)
            {
                sqlSb.Append($"WHERE \"{parameters[0].name}\" = @{parameters[0].name}");
                paramsObject.TryAdd(parameters[0].name, parameters[0].value);
            }
            for (int i = 1; i < parameters.Length; i++)
            {
                sqlSb.Append($"  AND \"{parameters[i].name}\" = @{parameters[i].name}");
                paramsObject.TryAdd(parameters[i].name, parameters[i].value);
            }

            _db.Open();
            var result = await _db.QueryAsync<TValue>(sqlSb.ToString(), paramsObject);
            await _db.CloseAsync();

            return result;
        }

        public async Task<TValue> GetEntityByIdAsync(Guid entityId, string tableName)
        {
            var sqlQuery = $"SELECT * FROM \"{tableName}\" WHERE \"Id\" = @entityId";
            _db.Open();
            var result = await _db.QueryFirstOrDefaultAsync<TValue>(sqlQuery, new { entityId = entityId });
            await _db.CloseAsync();

            return result;
        }
    }
}
