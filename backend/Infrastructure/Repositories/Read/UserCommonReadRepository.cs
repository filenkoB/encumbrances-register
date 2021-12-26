using Application.Enumerations;
using Domain.Interfaces;
using Infrastructure.Dapper;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using System;
using System.Text;

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

        public async Task<string> GetUserEmailAsync(Guid userId, UserType userType)
        {
            StringBuilder sb = new StringBuilder("SELECT \"Email\" FROM [#Table#] WHERE \"Id\" = @userId");
            switch(userType)
            {
                case UserType.Admin:
                    sb.Replace("[#Table#]", "\"Admins\"");
                    break;
                case UserType.Registrator:
                    sb.Replace("[#Table#]", "\"Registrators\"");
                    break;
                case UserType.SimpleUser:
                    sb.Replace("[#Table#]", "\"Users\"");
                    break;
            }
            _db.Open();
            var result = await _db.QueryFirstAsync<string>(sb.ToString(), new { userId = userId });
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
