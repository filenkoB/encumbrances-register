using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Read
{
    public interface IStatementReadRepository
    {
        public Task<IEnumerable<BsonDocument>> GetUserRegistrationStatementsAsync(int page, int length);
        public Task<IEnumerable<BsonDocument>> GetStatementsWithOffsetAsync(int page, int length);
        public Task<BsonDocument> GetStatementAsync(Guid statementId);
        public Task<long> GetStatementsNumberAsync();
        public Task<long> GetRegistrationStatementsNumberAsync();
        public Task<IEnumerable<BsonDocument>> GetUserStatementsAsync(int page, int length, Guid userId);
    }
}
