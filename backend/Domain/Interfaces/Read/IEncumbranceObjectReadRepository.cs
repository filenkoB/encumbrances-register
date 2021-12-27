using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEncumbranceObjectReadRepository
    {
        public Task<BsonDocument> GetEncumbranceObjectById(Guid objectId);
    }
}
