using Domain.Entities;
using Domain.Interfaces;
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

namespace Infrastructure.Repositories
{
    public class EncumbranceReadRepository : IEncumbranceReadRepository
    {
        private readonly NpgsqlConnection _db;

        public EncumbranceReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }
        public async Task<IEnumerable<ShortEncumbrance>> GetEncumbrancesByFilterAsync(EncumbrancesFilter filter)
        {
            _db.Open();
            var result = await _db.QueryAsync<ShortEncumbrance>("GetEncumbrances", new
                {
                    encumbranceRegistrationNumber = filter.EncumbranceRegistrationNumber,
                    objectId = filter.ObjectId,
                    debtorFirstName = filter.DebtorFirstName,
                    debtorLastName = filter.DebtorLastName,
                    debtorPatronymic = filter.DebtorPatronymic,
                    debtorTaxpayerACN = filter.DebtopTaxpayerACN,
                    debtorDepName = filter.DebtopDepName,
                    debtorDepIdentificator = filter.DebtorIdentificator
                },
                commandType: CommandType.StoredProcedure
            ); ;
            await _db.CloseAsync();
            return result;
        }

        public async Task<Encumbrance> GetEncumbranceByIdAsync(Guid encumbranceId)
        {
            _db.Open();
            string sqlQuery = "SELECT * FROM \"Encumbrances\" WHERE \"Id\" = @encumbranceId";
            var result = await _db.QueryFirstOrDefaultAsync<Encumbrance>(sqlQuery, new { encumbranceId = encumbranceId });
            await _db.CloseAsync();
            return result;
        }
    }
}
