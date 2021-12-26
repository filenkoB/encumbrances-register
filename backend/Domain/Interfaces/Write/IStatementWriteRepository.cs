using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Write
{
    public interface IStatementWriteRepository
    {
        public Task AddStatementAsync(BsonDocument statementDocument);
        public Task<string> GetNewStatementNumber();
        public Task UpdateStatementTouchedStatusAsync(Guid statementId);
        public Task UpdateEncumbranceStatementStatus(Guid statementId, int status);
    }
}
