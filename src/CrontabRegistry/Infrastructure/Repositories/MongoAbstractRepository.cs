using CrontabRegistry.Domain.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrontabRegistry.Infrastructure.Repositories
{
    public class MongoAbstractRepository
    {
        protected IMongoClient _mongoClient;
        protected CrontabRegistryDatabaseOptions _databaseOptions;
        protected IMongoDatabase _contextDb;

        public MongoAbstractRepository(
            IMongoClient mongoClient,
            IOptions<CrontabRegistryDatabaseOptions> options
        )
        {
            _mongoClient = mongoClient;
            _databaseOptions = options.Value;
            _contextDb = _mongoClient.GetDatabase(_databaseOptions.DatabaseName);
        }
    }
}
