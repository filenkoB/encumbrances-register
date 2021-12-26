using Domain.Interfaces;
using Domain.Interfaces.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Read
{
    public class EncumbranceObjectReadRepository : IEncumbranceObjectReadRepository
    {
        private readonly IMongoConnectionFactory _db;

        public EncumbranceObjectReadRepository(IMongoConnectionFactory mongoConnectionFactory)
        {
            _db = mongoConnectionFactory;
        }
        public async Task<BsonDocument> GetEncumbranceObjectById(Guid objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(new StringFieldDefinition<BsonDocument, Guid>("_id"), objectId);
            return await _db.EncumbranceObjects.Find(filter).FirstOrDefaultAsync();
        }
    }
}
