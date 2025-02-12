using MeteoServerProject.OpenMeteo;
using Microsoft.AspNetCore.Mvc;

namespace MeteoServerProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		OpenMeteoRequestHandler OpenMeteoRequestHandler { get;}
		public WeatherForecastController(OpenMeteoRequestHandler openMeteoRequestHandler)
		{
			OpenMeteoRequestHandler = openMeteoRequestHandler;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public async Task<IActionResult> Get(double latitude, double longitude)
		{
			return Ok(await OpenMeteoRequestHandler.GetWeatherDataForLocation(new WeatherRequestPoint() { Latitude = latitude,Longitude=longitude }));
		}
	}
}
