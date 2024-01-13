using CrontabRegistry.Domain.Models;
using CrontabRegistry.Domain.Options;
using CrontabRegistry.Domain.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrontabRegistry.Infrastructure.Repositories
{
    public class WeatherForecastRepository : MongoAbstractRepository, IWeatherForecastRepository
    {
        public WeatherForecastRepository(
            IMongoClient mongoClient,
            IOptions<CrontabRegistryDatabaseOptions> options
        ) : base(mongoClient, options)
        {
        }

        public async Task<string[]> GetSummaries()
        {
            var data = await GetSummariesData();
            var summariesList = new List<string>();

            foreach (var item in data)
            {
                summariesList.Add(item.Name ?? "");
            }

            return summariesList.ToArray();
        }

        private async Task<IList<SummarieModel>> GetSummariesData()
        {
            var summariesCollection = _contextDb.GetCollection<SummarieModel>("summaries");
            return await summariesCollection.Find(_ => true).ToListAsync();
        }
    }
}
