using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Docker_Pipeline_Test.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly WeatherforecastConfig _config;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<WeatherforecastConfig> config)
		{
			_logger = logger;
			_config = config.Value;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public WeatherForecast Get()
		{
			return new WeatherForecast
			{
				Date = DateTime.UtcNow,
				Summary =  _config.EnvironmentName
			};
		}
	}
}
