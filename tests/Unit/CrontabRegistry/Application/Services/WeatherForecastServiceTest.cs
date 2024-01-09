using CrontabRegistry.Application.Services;
using CrontabRegistry.Domain.Services;
using FluentAssertions;

namespace Unit.CrontabRegistry.Application.Services
{
    public class WeatherForecastServiceTest
    {
        private IWeatherForecastService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new WeatherForecastService();
        }

        [Test]
        public void GenerateWeatherForecast_should_return_random_data()
        {
            // arrange

            // act
            var results = _sut.GenerateWeatherForecast();

            // assert
            results.Should().HaveCount(5);
        }

    }
}
