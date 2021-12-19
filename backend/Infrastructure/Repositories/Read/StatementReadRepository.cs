using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Read;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Read
{
    public class StatementReadRepository : IStatementReadRepository
    {
        private readonly IMongoConnectionFactory _db;
        public StatementReadRepository(IMongoConnectionFactory mongoConnectionFactory)
        {
            _db = mongoConnectionFactory;
        }
        public async Task<IEnumerable<BsonDocument>> GetStatementsWithOffsetAsync(int page, int length)
        {
            return await _db.Statements.Find(_ => true).Skip((page - 1) * length).Limit(length).ToListAsync();
        }

        public async Task<BsonDocument> GetStatementAsync(Guid statementId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), statementId);
            return await _db.Statements.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<long> GetStatementsNumberAsync()
        {
            return await _db.Statements.CountDocumentsAsync(new BsonDocument());
        }
    }
}
