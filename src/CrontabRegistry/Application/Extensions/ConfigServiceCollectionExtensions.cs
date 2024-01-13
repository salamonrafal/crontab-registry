using CrontabRegistry.Application.Services;
using CrontabRegistry.Domain.Options;
using CrontabRegistry.Domain.Repositories;
using CrontabRegistry.Domain.Services;
using CrontabRegistry.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services = AddMongoClient(services, configuration);
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            return services;
        }

        private static IServiceCollection AddMongoClient(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CrontabRegistryDatabaseOptions>(
                configuration.GetSection(nameof(CrontabRegistryDatabaseOptions))
            );
            var mongodbClient = new MongoClient();

            services.AddScoped<IMongoClient, MongoClient>(
                serviceProvider => {
                    var crontabRegistryDatabaseOptions = serviceProvider
                        .GetRequiredService<IOptions<CrontabRegistryDatabaseOptions>>().Value;
                    return new MongoClient(crontabRegistryDatabaseOptions.ConnectionString);
                }
            );

            return services;
        }
    }
}
