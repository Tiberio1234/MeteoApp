using MeteoServerProject;
using MeteoServerProject.OpenMeteo;

namespace MeteoApp.Components.Services
{
	public class WeatherDataService
	{
		private readonly HttpClient _httpClient;
		private static readonly string BaseUrl = "http://localhost:5285"; // Your local server address

		public WeatherDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(BaseUrl);
		}

		public async Task<List<WeatherData>> GetWeatherForecastAsync(WeatherRequestPoint weatherRequestPoint)
		{
			try
			{
				var response = await _httpClient.GetAsync(
					$"{BaseUrl}/WeatherForecast?latitude={weatherRequestPoint.Latitude}&longitude={weatherRequestPoint.Longitude}");

				response.EnsureSuccessStatusCode();

				var forecast = await response.Content.ReadFromJsonAsync<List<WeatherData>>();
				return forecast;
			}
			catch (HttpRequestException ex)
			{
				// Log the error or handle it as needed
				throw new Exception($"Error fetching weather data: {ex.Message}", ex);
			}
		}
	}
}
