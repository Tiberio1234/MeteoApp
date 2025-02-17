using MeteoServerProject.OpenMeteo;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text;
using System.Text.Json;

namespace TestProject
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}

		[Test]
		public async Task GetForecastDataAsync_SuccessfulResponse_ReturnsForecastData()
		{
			// Arrange
			var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
			var weatherRequestPoint = new WeatherRequestPoint { Latitude = 40.7128, Longitude = -74.0060 };
			var expectedForecast = new OpenMeteoWeatherForecastHourData(); // Populate with expected test data
			var fakeResponse = JsonSerializer.Serialize(new OpenMeteoWeatherForecastData { HourlyData = expectedForecast });

			mockHttpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>("SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(fakeResponse, Encoding.UTF8, "application/json")
				});

			var httpClient = new HttpClient(mockHttpMessageHandler.Object);
			var mockHttpClientFactory = new Mock<IHttpClientFactory>();
			mockHttpClientFactory.Setup(f => f.CreateClient(nameof(OpenMeteoRequestHandler))).Returns(httpClient);
			var weatherService = new OpenMeteoRequestHandler(mockHttpClientFactory.Object);

			// Act
			var result = await weatherService.GetForecastDataAsync(weatherRequestPoint);

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual(expectedForecast.Time, result.Time);
		}

		[Test]
		public async Task AddNr()
		{
			// Simple test example
			int a = 5;
			int b = 10;
			int sum = a + b;

			Assert.AreEqual(15, sum);
		}


	}
}