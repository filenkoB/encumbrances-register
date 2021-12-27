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
            var filter = Builders<BsonDocument>.Filter.Exists(new StringFieldDefinition<BsonDocument, Guid>("StatementTypeId")) &
                Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, int>("Status"), 0);
            return await _db.Statements.Find(filter).Skip((page - 1) * length).Limit(length).ToListAsync(); ;
        }

        public async Task<BsonDocument> GetStatementAsync(Guid statementId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), statementId);
            return await _db.Statements.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<long> GetStatementsNumberAsync()
        {
            var filter = Builders<BsonDocument>.Filter.Exists(new StringFieldDefinition<BsonDocument, Guid>("StatementTypeId")) &
                Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, int>("Status"), 0);
            return await _db.Statements.CountDocumentsAsync(filter);
        }

        public async Task<IEnumerable<BsonDocument>> GetUserRegistrationStatementsAsync(int page, int length)
        {
            var filter = Builders<BsonDocument>.Filter
                .Not(Builders<BsonDocument>.Filter.Exists(new StringFieldDefinition<BsonDocument, Guid>("StatementTypeId"))) &
                Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, bool>("IsTouched"), false);
            return await _db.Statements.Find(filter).Skip((page - 1) * length).Limit(length).ToListAsync();
        }

        public async Task<long> GetRegistrationStatementsNumberAsync()
        {
            var filter = Builders<BsonDocument>.Filter
                .Not(Builders<BsonDocument>.Filter.Exists(new StringFieldDefinition<BsonDocument, Guid>("StatementTypeId"))) &
                Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, bool>("IsTouched"), false);
            return await _db.Statements.CountDocumentsAsync(filter);
        }

        public async Task<IEnumerable<BsonDocument>> GetUserStatementsAsync(int page, int length, Guid userId)
        {
            var filter = Builders<BsonDocument>.Filter.Exists(new StringFieldDefinition<BsonDocument, Guid>("StatementTypeId")) &
                Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("StatementOwnerId"), userId);
            return await _db.Statements.Find(filter).Skip((page - 1) * length).Limit(length).ToListAsync();
        }

        public async Task<long> GetUserStatementsNumberAsync(Guid userId)
        {
            var filter = Builders<BsonDocument>.Filter.Exists(new StringFieldDefinition<BsonDocument, Guid>("StatementTypeId")) &
                Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("StatementOwnerId"), userId);
            return await _db.Statements.CountDocumentsAsync(filter);
        }
    }
}
