using System.Text.Json.Serialization;

namespace MeteoApp.Components.OpenMeteo
{
	public class OpenMeteoWeatherForecastData
	{
		[JsonPropertyName("hourly")]
		public OpenMeteoWeatherForecastHourData HourlyData { get; set; }
	}

}
