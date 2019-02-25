using System.Configuration;
using System.Data.Entity;
using MongoDB.Driver;

namespace AData.MongoDB
{
    public class MongoDbContext : DbContext
    {
        private readonly IMongoDatabase MongoDatabase;

        public MongoDbContext()
            : this("MongoDbContext")
        {
            
        }

        private MongoDbContext(string connectionName)
        {
            var url = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            var mongoUrl = new MongoUrl(url);
            IMongoClient client = new MongoClient(mongoUrl);
            MongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<TEntity> Collection<TEntity>() where TEntity : Entity
        {
            string collectionName = CollectionName<TEntity>();

            return MongoDatabase.GetCollection<TEntity>(collectionName);
        }

        private static string CollectionName<TEntity>()
        {
            var type = typeof(TEntity);

            return type.Name;
        }

    }
}
