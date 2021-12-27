using MongoDB.Bson;
using System.Threading.Tasks;

namespace Domain.Interfaces.Write
{
    public interface IPayementSertificateWriteRepository
    {
        public Task InsertAsync(BsonDocument document);
    }
}
