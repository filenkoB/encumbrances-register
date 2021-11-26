using MongoDB.Bson;
using MongoDB.Driver;

namespace Domain.Interfaces.MongoDB
{
    public interface IMongoStatement : IMongoEntitiesIniter<BsonDocument, IMongoStatement>
    {
        IMongoCollection<BsonDocument> Statements { get; set; }
        public void InitCurrentCollection(IMongoDatabase db)
        {
            InitCollection(Statements, db);
        }
    }
}