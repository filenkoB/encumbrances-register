using Domain.Interfaces;
using Domain.PostgreSQL.Entities;
using System.Threading.Tasks;
using Infrastructure.EF.PostgreSQL;
using System;
using Infrastructure.Dapper;
using Dapper;
using Npgsql;
using Domain.Interfaces.Write;

namespace Infrastructure.Repositories
{
    public class UserRegistratorWriteRepository : IUserRegistratorWriteRepository
    {
        private readonly EncumbrancesRegisterDbContext _db;
        private readonly NpgsqlConnection _dbDapper;

        public UserRegistratorWriteRepository(EncumbrancesRegisterDbContext db, PostgresConnectionFactory dbDapper)
        {
            _db = db;
            _dbDapper = dbDapper.Connection;
        }
        public async Task UpdateRegistratorAsync(Registrator registrator)
        {
            _db.Registrators.Update(registrator);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task<Identificator> InsertUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return await GetCreatedIdentificatorAsync(user.Id, "Users");
        }
        public async Task<Identificator> InsertRegistratorAsync(Registrator registrator)
        {
            await _db.Registrators.AddAsync(registrator);
            await _db.SaveChangesAsync();

            return await GetCreatedIdentificatorAsync(registrator.Id, "Registrators");
        }

        private async Task<Identificator> GetCreatedIdentificatorAsync(Guid userId, string tableName)
        {
            string sqlQuery =
                "SELECT \"i\".* FROM \"Identificators\" \"i\" " +
                $"INNER JOIN \"{tableName}\" \"t\" ON \"i\".\"Login\" = \"t\".\"IdentificatorId\" " +
                "WHERE \"t\".\"Id\" = @userId";

            return await _dbDapper.QueryFirstAsync<Identificator>(sqlQuery, new { userId = userId });
        }
    }
}
