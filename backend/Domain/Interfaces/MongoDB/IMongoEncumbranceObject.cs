using MongoDB.Bson;
using MongoDB.Driver;

namespace Domain.Interfaces.MongoDB
{
    public interface IMongoEncumbranceObject : IMongoEntitiesIniter<BsonDocument, IMongoEncumbranceObject>
    {
        IMongoCollection<BsonDocument> EncumbranceObjects { get; set; }

        public void InitCurrentCollection(IMongoDatabase db)
        {
            InitCollection(EncumbranceObjects, db);
        }
    }
}