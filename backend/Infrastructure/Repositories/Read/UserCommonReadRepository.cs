using Application.Enumerations;
using Domain.Interfaces;
using Infrastructure.Dapper;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using System;

namespace Infrastructure.Repositories
{
    public class UserCommonReadRepository : IUserCommonReadRepository
    {
        private readonly NpgsqlConnection _db;
        public UserCommonReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }

        public async Task<Guid> GetUserByCredentialsAsync(string login, string password)
        {
            _db.Open();
            string sqlQuery = "SELECT \"u\".\"Id\" " +
                "FROM \"Identificators\" \"i\" " +
                "INNER JOIN \"Users\" \"u\" ON \"u\".\"IdentificatorId\" = @login " +
                "WHERE \"Password\" = @password " +
                "UNION ALL " +
                "SELECT \"r\".\"Id\" " +
                "FROM \"Identificators\" \"i\" " +
                "INNER JOIN \"Registrators\" \"r\" ON \"r\".\"IdentificatorId\" = @login " +
                "WHERE \"Password\" = @password " +
                "UNION ALL " +
                "SELECT \"a\".\"Id\" " +
                "FROM \"Identificators\" \"i\" " +
                "INNER JOIN \"Admins\" \"a\" ON \"a\".\"IdentificatorId\" = @login " +
                "WHERE \"Password\" = @password ";
            var result = await _db.QueryFirstOrDefaultAsync<Guid>(sqlQuery, new { login = login, password = password });
            await _db.CloseAsync();
            return result;
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
