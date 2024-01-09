using CrontabRegistry.Domain.Repositories;

namespace CrontabRegistry.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public string[] GetSummaries()
        {
            return new[]
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
        }
    }
}
