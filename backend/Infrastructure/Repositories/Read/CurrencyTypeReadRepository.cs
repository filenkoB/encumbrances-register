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
    public class CurrencyTypeReadRepository : ICurrencyTypeReadRepository
    {
        private readonly NpgsqlConnection _db;
        public CurrencyTypeReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }
        public async Task<IEnumerable<CurrencyType>> GetAllCurrencyTypesAsync()
        {
            _db.Open();
            var sql = "SELECT * FROM \"CurrencyTypes\"";
            var result = await _db.QueryAsync<CurrencyType>(sql);
            await _db.CloseAsync();
            return result;
        }
    }
}
