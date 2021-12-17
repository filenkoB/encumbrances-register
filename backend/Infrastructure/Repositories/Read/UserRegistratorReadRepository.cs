using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.PostgreSQL.Entities;
using Infrastructure.Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRegistratorReadRepository : IUserRegistratorReadRepository 
    {
        private readonly NpgsqlConnection _db;
        public UserRegistratorReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }
        public async Task<IEnumerable<RegistratorAction>> GetActiveRegistratorActionsAsync(Guid registratorId)
        {
            _db.Open();
            string sqlQuery = "SELECT * FROM \"GetRegistratorActions\"(@registratorId)";
            var result = await _db.QueryAsync<RegistratorAction>(sqlQuery, new { registratorId = registratorId });
            await _db.CloseAsync();
            return result;
        }

        public async Task<IEnumerable<Registrator>> GetActiveRegistratorsAsync()
        {
            _db.Open();
            string sqlQuery =
                "SELECT \"r\".* FROM \"Registrators\" \"r\" " +
                "INNER JOIN \"Identificators\" \"i\" ON \"i\".\"Login\" == \"r\".\"IdentificatorId\" " +
                "WHERE \"i\".\"Status\" = 1";
            var result = await _db.QueryAsync<Registrator>(sqlQuery);
            await _db.CloseAsync();
            return result;
    }
}
}
