using Domain.Entities;
using Domain.Interfaces;
using Domain.PostgreSQL.Entities;
using Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Domain.Exceptions;

namespace Infrastructure.Repositories
{
    public class EncumbranceReadRepository : IEncumbranceReadRepository
    {
        private readonly NpgsqlConnection _db;

        public EncumbranceReadRepository(PostgresConnectionFactory postgresConnectionFactory)
        {
            _db = postgresConnectionFactory.Connection;
        }
        public async Task<IEnumerable<Encumbrance>> GetEncumbrancesByFilterAsync(EncumbranceSelectFilter filter)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"GetEncumbrances\"(@encumbranceNumber, @name, @idNumber) WHERE \"Id\" IS NOT NULL";
            var result = await _db.QueryAsync<Encumbrance>(sqlQuery, new
                {
                    encumbranceNumber = filter.EncumbranceNumber,
                    name = filter.Name,
                    idNumber = filter.IdNumber,
                }
            );
            await _db.CloseAsync();
            return result;
        }

        public async Task<IEnumerable<Encumbrance>> GetEncumbranesAsync()
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Encumbrances\"";
            var result = await _db.QueryAsync<Encumbrance>(sqlQuery);
            await _db.CloseAsync();

            return result;
        }

        public async Task<Encumbrance> GetEncumbranceAsync(Guid encumbranceId)
        {
            var sqlQuery = "SELECT * FROM \"Encumbrances\" WHERE \"Id\" = @encumbranceId";
            _db.Open();
            var encumbrance = await _db.QueryFirstAsync(sqlQuery, new { encumbranceId = encumbranceId });
            await _db.CloseAsync();
            return encumbrance;
        }

        public async Task<long> GetNextEncumbranceNumberAsync()
        {
            var sqlQuery = "SELECT COUNT(1) FROM \"Encumbrances\"";
            _db.Open();
            var count = await _db.QuerySingleAsync<int>(sqlQuery);
            await _db.CloseAsync();

            return count + 1;
        }

        public async Task<ExtractEncumbrance> GetExtractEncumbrance(Guid encumbranceId)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"GetExtractEncumbranceInfo\"(@encumbranceId)";
            var result = await _db.QueryFirstAsync<ExtractEncumbrance>(sqlQuery, new { encumbranceId = encumbranceId });

            await _db.CloseAsync();
            return result;
        }

        public async Task<Encumbrance> GetEncumbranceByRegNumber(string regNumber)
        {
            _db.Open();
            var sqlQuery = "SELECT * FROM \"Encumbrances\" WHERE \"Number\" = @regNumber";
            var result = await _db.QueryFirstOrDefaultAsync<Encumbrance>(sqlQuery, new { regNumber = regNumber });
            await _db.CloseAsync();
            if (result == default)
            {
                throw new EntityNotFoundException($"За вашим запитом не було знайдено обтяження з номером {regNumber}");
            }

            return result;
        }
    }
}
