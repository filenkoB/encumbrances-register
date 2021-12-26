using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Write;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Write
{
    public class StatementWriteRepository : IStatementWriteRepository
    {
        private readonly IMongoConnectionFactory _db;
        public StatementWriteRepository(IMongoConnectionFactory mongoConnectionFactory)
        {
            _db = mongoConnectionFactory;
        }
        public async Task AddStatementAsync(BsonDocument statementDocument)
        {
            await _db.Statements.InsertOneAsync(statementDocument);
        }

        public async Task UpdateStatementTouchedStatusAsync(Guid statementId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), statementId);
            var statement = await _db.Statements.Find(filter).FirstOrDefaultAsync();
            statement["IsTouched"] = true;
            await _db.Statements.ReplaceOneAsync(filter, statement);
        }

        public async Task<string> GetNewStatementNumber()
        {
            return (await _db.Statements.CountDocumentsAsync(new BsonDocument()) + 1).ToString();
        }

        public async Task UpdateEncumbranceStatementStatus(Guid statementId, int status)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), statementId);
            var statement = await _db.Statements.Find(filter).FirstOrDefaultAsync();
            statement["Status"] = status;
            await _db.Statements.ReplaceOneAsync(filter, statement);
        }
    }
}
