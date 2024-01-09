using CrontabRegistry.Domain.Models;
using System.Collections.Generic;

namespace CrontabRegistry.Domain.Services
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GenerateWeatherForecast();
    }
}
