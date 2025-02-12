using System.Text.Json.Serialization;

namespace MeteoServerProject.OpenMeteo
{
	public class OpenMeteoWeatherForecastData
	{
		[JsonPropertyName("hourly")]
		public OpenMeteoWeatherForecastHourData HourlyData { get; set; }
	}

}
