using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Write
{
    public interface IMongoWriteRepository
    {
        public Task InsertDocumentAsync(BsonDocument document);
        public Task UpdateDocumentAsync(BsonDocument document);
        public Task DeleteDocumentAsync(Guid objectId);
    }
}
