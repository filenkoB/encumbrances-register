using System;
using MongoDB.Driver;

namespace Domain.Interfaces.MongoDB
{
    public interface IMongoConnectionFactory : IMongoEncumbranceObject, IMongoPaymentSertificate, IMongoStatement
    {
        private static string _mongoDatabaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE");
        private static MongoClient _client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING"));
        
        public static IMongoDatabase db = _client == null
            ? new MongoClient(Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING")).GetDatabase(_mongoDatabaseName)
            : _client.GetDatabase(_mongoDatabaseName);
        public void InitEntityLists()
        {
            Type[] parentInterfaces = this.GetType().GetInterfaces();

            foreach(var parentInterface in parentInterfaces)
            {
                parentInterface.GetMethod("InitCurrentCollection").Invoke(this, new object[] { db });
            }
        }
    }
}
