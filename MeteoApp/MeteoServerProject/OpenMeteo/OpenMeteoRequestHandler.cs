using System.Text.Json;

namespace MeteoServerProject.OpenMeteo
{
	/// <summary>
	/// Handles requests to the OpenMeteo weather service
	/// </summary>
	public class OpenMeteoRequestHandler
	{
		/// <summary>
		/// The HTTP client used for making requests
		/// </summary>
		public HttpClient HttpClient { get; }

		public OpenMeteoRequestHandler(IHttpClientFactory httpClientFactory)
		{
			HttpClient = httpClientFactory.CreateClient(nameof(OpenMeteoRequestHandler));
		}


		/// <summary>
		/// Gets forecast data for a location
		/// </summary>
		/// <param name="weatherRequestPoint">The location for which to get the forecast data</param>
		/// <returns>The forecast data for the location</returns>
		/// <exception cref="HttpRequestException">Thrown when the API request fails</exception>
		public async Task<OpenMeteoWeatherForecastHourData> GetForecastDataAsync(WeatherRequestPoint weatherRequestPoint)
        {
            string requestUrl = $"https://api.open-meteo.com/v1/forecast?latitude={weatherRequestPoint.Latitude}&longitude={weatherRequestPoint.Longitude}&hourly=temperature_2m,relative_humidity_2m,precipitation_probability,cloud_cover,wind_speed_10m";
            HttpResponseMessage response = await HttpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var forecast = JsonSerializer.Deserialize<OpenMeteoWeatherForecastData>(data);
                return forecast.HourlyData;
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}");
            }
        }

		
		public async Task<List<WeatherData>> GetWeatherDataForLocation(WeatherRequestPoint weatherRequestPoint)
        {
            var forecastData = await GetForecastDataAsync(weatherRequestPoint);
            return await MapOpenMeteoWeatherForecastHourDataToWeatherDataList(forecastData);
        }

		/// <summary>
		/// Maps OpenMeteoWeatherForecastHourData to a list of WeatherData
		/// </summary>
		/// <param name="hourData">The forecast data to map</param>
		/// <returns>The mapped forecast data</returns>
		private Task<List<WeatherData>> MapOpenMeteoWeatherForecastHourDataToWeatherDataList(OpenMeteoWeatherForecastHourData hourData)
        {
            var weatherDataList = new List<WeatherData>();

            for (int i = 0; i < hourData.Time.Count; i++)
            {
                var weatherData = new WeatherData
                {
                    Time = hourData.Time[i],
                    Temperature = hourData.Temperature[i],
                    WindSpeed = hourData.WindSpeed[i],
                    Humidity = hourData.Humidity[i],
                    PrecipitationProbability = hourData.PrecipitationProbability[i],
                    CloudCover = hourData.CloudCover[i]
                };
                weatherDataList.Add(weatherData);
            }

            return Task.FromResult(weatherDataList);
        }

    }
}
