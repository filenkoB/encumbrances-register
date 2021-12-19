using MongoDB.Bson;
using System.Threading.Tasks;

namespace Domain.Interfaces.Write
{
    public interface IStatementWriteRepository
    {
        public Task AddStatementAsync(BsonDocument statementDocument);
        public Task<string> GetNewStatementNumber();
    }
}
