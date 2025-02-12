using System.Text.Json.Serialization;

namespace MeteoServerProject.OpenMeteo
{
	public class WeatherData
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public double PrecipitationProbability { get; set; }

        [JsonPropertyName("cloud_cover")]
        public double CloudCover { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

    }
}
