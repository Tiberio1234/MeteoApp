using System.Reflection;
using System.Text.Json.Serialization;

namespace MeteoServerProject.OpenMeteo
{
    public class OpenMeteoWeatherForecastHourData 
	{
		[JsonPropertyName("time")]
		public List<string> Time { get; set; }

		[JsonPropertyName("temperature_2m")]
		public List<double> Temperature { get; set; }

		[JsonPropertyName("relative_humidity_2m")]
		public List<double> Humidity { get; set; }

		[JsonPropertyName("precipitation_probability")]
		public List<double> PrecipitationProbability { get; set; }

		[JsonPropertyName("cloud_cover")]
		public List<double> CloudCover { get; set; }

		[JsonPropertyName("wind_speed_10m")]
		public List<double> WindSpeed { get; set; }

	}
}
