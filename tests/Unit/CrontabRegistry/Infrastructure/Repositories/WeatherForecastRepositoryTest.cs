using CrontabRegistry.Domain.Options;
using CrontabRegistry.Domain.Repositories;
using CrontabRegistry.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

namespace Unit.CrontabRegistry.Infrastructure.Repositories
{
    public class WeatherForecastRepositoryTest
    {
        private IWeatherForecastRepository _sut;
        private Mock<IMongoClient> _mockMongoClient;
        private IOptions<CrontabRegistryDatabaseOptions> _options;

        [SetUp]
        public void SetUp()
        {
            _mockMongoClient = new Mock<IMongoClient>(MockBehavior.Strict);
            _options = Options.Create(new CrontabRegistryDatabaseOptions() 
            { 
                ConnectionString = "mongodb://test",
                DatabaseName = "test",
                SummariesCollectionName = "test",
            });
            _sut = new WeatherForecastRepository(_mockMongoClient.Object, _options);
        }

        [TearDown]
        public void TearDown()
        {
            _mockMongoClient.VerifyAll();
        }

        [Test]
        public async Task GetSummariesLshould_return_list_of_summaries_as_array_of_strings()
        {
            // arrange
            var expectedSummaries = new[]
            {
                "Freezing",
                "Bracing",
                "Chilly",
                "Cool",
                "Mild",
                "Warm",
                "Balmy",
                "Hot",
                "Sweltering",
                "Scorching"
            };

            // act
            var results = await _sut.GetSummaries();

            // assert
            results.Should().Equal(expectedSummaries);
        }
    }
}
