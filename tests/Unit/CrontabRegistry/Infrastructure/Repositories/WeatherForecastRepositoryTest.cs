using CrontabRegistry.Domain.Repositories;
using CrontabRegistry.Infrastructure.Repositories;
using FluentAssertions;

namespace Unit.CrontabRegistry.Infrastructure.Repositories
{
    public class WeatherForecastRepositoryTest
    {
        private IWeatherForecastRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new WeatherForecastRepository();
        }

        [Test]
        public void GetSummariesLshould_return_list_of_summaries_as_array_of_strings()
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
            var results = _sut.GetSummaries();

            // assert
            results.Should().Equal(expectedSummaries);
        }
    }
}
