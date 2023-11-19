using Docker_Pipeline_Test;
using Docker_Pipeline_Test.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;

namespace xUnitTests
{
	public class WeatherforecastConfig_Should
	{
		[Theory]
		[InlineData("D1")]
		public void Return_EnvironmentName(string envName)
		{
			var config  = Options.Create( new WeatherforecastConfig { 
				EnvironmentName = envName
			});

			var logger = NSubstitute.Substitute.For<ILogger<WeatherForecastController>>();

			var sut = new WeatherForecastController(logger, config);

			var response = sut.Get();

			Assert.Equal(envName, response.Summary);

		}
	}
}