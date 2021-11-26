using MongoDB.Driver;
using System.Linq;

namespace Domain.Interfaces.MongoDB
{
    public interface IMongoEntitiesIniter<TEntity, TClass>
    {
        public void InitCollection(IMongoCollection<TEntity> collection, IMongoDatabase db)
        {
            collection = db.GetCollection<TEntity>(
               string.Join("", typeof(TClass).Name.Except("IMongo"))
            );
        }
    }
}
