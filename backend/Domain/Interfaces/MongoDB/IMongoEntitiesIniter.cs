using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Domain.Interfaces.MongoDB
{
    public interface IMongoEntitiesIniter<TEntity, TClass>
    {
        public IMongoCollection<BsonDocument> InitCollection(IMongoDatabase db)
        {
            return db.GetCollection<BsonDocument>(
               string.Join("", typeof(TClass).Name.Split("IMongo"))
            );
        }
    }
}
