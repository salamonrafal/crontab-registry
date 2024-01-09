namespace CrontabRegistry.Domain.Repositories
{
    public interface IWeatherForecastRepository
    {
        public string[] GetSummaries();
    }
}
