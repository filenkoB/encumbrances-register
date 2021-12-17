using Application.Enumerations;
using Domain.Interfaces;
using Infrastructure.Dapper;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Npgsql;

namespace Infrastructure.Repositories
{
    public class UserCommonReadRepository : IUserCommonReadRepository
    {
        private readonly NpgsqlConnection _db;
        public UserCommonReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }

        public async Task<UserType> GetUserTypeByIdentificatorAsync(string login)
        {
            _db.Open();
            string sqlQuery =  "SELECT \"GetUserTypeByLogin\"(@login)";
            var result = (UserType)(await _db.QueryFirstAsync<int>(sqlQuery, new { login = login }));
            await _db.CloseAsync();
            return result;
        }
    }
}
