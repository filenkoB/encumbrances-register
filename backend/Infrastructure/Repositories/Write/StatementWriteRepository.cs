using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Write;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Write
{
    public class StatementWriteRepository : IStatementWriteRepository
    {
        private readonly IMongoConnectionFactory _db;
        public StatementWriteRepository(IMongoConnectionFactory mongoConnectionFactory)
        {
            _db = mongoConnectionFactory;
        }
        public async Task AddStatementAsync(BsonDocument statementDocument)
        {
            await _db.Statements.InsertOneAsync(statementDocument);
        }

        public async Task<string> GetNewStatementNumber()
        {
            return (await _db.Statements.CountDocumentsAsync(new BsonDocument()) + 1).ToString();
        }
    }
}
