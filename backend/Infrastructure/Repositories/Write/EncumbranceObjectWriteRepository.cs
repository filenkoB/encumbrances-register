using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Write;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Write
{
    public interface IEncumbranceObjectWriteRepository : IMongoWriteRepository
    { }

    public class EncumbranceObjectWriteRepository : IEncumbranceObjectWriteRepository
    {
        private readonly IMongoConnectionFactory _db;

        public EncumbranceObjectWriteRepository(IMongoConnectionFactory mongoConnectionFactory)
        {
            _db = mongoConnectionFactory;
        }
        public async Task DeleteDocumentAsync(Guid objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), objectId);
            await _db.Statements.DeleteOneAsync(filter);
        }

        public async Task InsertDocumentAsync(BsonDocument document)
        {
            await _db.EncumbranceObjects.InsertOneAsync(document);
        }

        public async Task UpdateDocumentAsync(BsonDocument document)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), document["_id"].AsGuid);
            await _db.Statements.ReplaceOneAsync(filter, document);
        }
    }
}
