using MongoDB.Bson;
using MongoDB.Driver;

namespace Domain.Interfaces.MongoDB
{
    public interface IMongoPaymentSertificate : IMongoEntitiesIniter<BsonDocument, IMongoPaymentSertificate>
    {
        IMongoCollection<BsonDocument> PaymentSertificates { get; set; }

        public void InitCurrentCollection(IMongoDatabase db)
        {
            InitCollection(PaymentSertificates, db);
        }
    }
}
