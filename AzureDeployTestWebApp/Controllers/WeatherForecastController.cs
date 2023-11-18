using Microsoft.AspNetCore.Mvc;

namespace AzureDeployTestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecast2Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecast2Controller> _logger;

        public WeatherForecast2Controller(ILogger<WeatherForecast2Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast2")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("\n__________________This is an information log__________________\n");
            _logger.LogWarning("\n__________________This is an warning log__________________\n");
            _logger.LogError("\n__________________This is an Error log__________________\n");

            _logger.LogTrace("\n__________________This is an Trrace log__________________\n");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}