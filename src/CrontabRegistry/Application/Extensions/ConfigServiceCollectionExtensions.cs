using CrontabRegistry.Application.Services;
using CrontabRegistry.Domain.Repositories;
using CrontabRegistry.Domain.Services;
using CrontabRegistry.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            return services;
        }
    }
}
