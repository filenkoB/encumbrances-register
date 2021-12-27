using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Write;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Write
{
    public class PayementSertificateWriteRepository : IPayementSertificateWriteRepository
    {
        private readonly IMongoConnectionFactory _db;

        public PayementSertificateWriteRepository(IMongoConnectionFactory mongoConnectionFactory)
        {
            _db = mongoConnectionFactory;
        }
        public async Task InsertAsync(BsonDocument document)
        {
            await _db.PaymentSertificates.InsertOneAsync(document);
        }
    }
}
