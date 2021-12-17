using Domain.Interfaces.Read;
using Domain.PostgreSQL.Entities;
using Infrastructure.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Npgsql;

namespace Infrastructure.Repositories.Read
{
    public class CountryReadRepository : ICountryReadRepository
    {
        private readonly NpgsqlConnection _db;
        public CountryReadRepository(PostgresConnectionFactory postgresConenctionFactory)
        {
            _db = postgresConenctionFactory.Connection;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Countries\"";
            var result = await _db.QueryAsync<Country>(sqlQuery);
            await _db.CloseAsync();
            return result;
        }
    }
}