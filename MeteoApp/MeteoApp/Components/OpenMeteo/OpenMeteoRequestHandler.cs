using MeteoApp.Components.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MeteoApp.Components.OpenMeteo
{
    public class OpenMeteoRequestHandler
	{
		private HttpClient HttpClient { get; }

		public OpenMeteoRequestHandler(IHttpClientFactory httpClientFactory)
		{
			HttpClient = httpClientFactory.CreateClient(nameof(OpenMeteoRequestHandler));
		}

        private async Task<OpenMeteoWeatherForecastHourData> GetForecastDataAsync(WeatherRequestPoint weatherRequestPoint)
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
