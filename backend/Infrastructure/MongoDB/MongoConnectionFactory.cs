using Domain.Interfaces.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.MongoDB
{
    public class MongoConnectionFactory : IMongoConnectionFactory
    {
        public IMongoCollection<BsonDocument> EncumbranceObjects { get; set; }
        public IMongoCollection<BsonDocument> Statements { get; set; }
        public IMongoCollection<BsonDocument> PaymentSertificates { get; set; }

        public MongoConnectionFactory()
        {
            (this as IMongoConnectionFactory).InitEntityLists();
        }
    }
}
