using MeteoApp.Components.Models;
using MeteoApp.Components.OpenMeteo;

namespace MeteoApp.Components.ViewModels
{
    public class WeatherViewModel
    {
        public List<WeatherData> WeatherDataList { get; set; } = [];

        public List<CityLocation> CityLocations { get; set; }
        public CityLocation SelectedCity { get; set; }

        public IList<WeatherData> SelectedWeatherItem {get; set; } = [];

        private OpenMeteoRequestHandler OpenMeteoRequestHandler { get; set; }

        public WeatherViewModel(OpenMeteoRequestHandler openMeteoRequestHandler)
        {
            CityLocations = new List<CityLocation>
            {
                new CityLocation { CityName = "Rome", WeatherRequestPoint = new WeatherRequestPoint { Latitude = 41.9028, Longitude = 12.4964 } },
                new CityLocation { CityName = "London", WeatherRequestPoint = new WeatherRequestPoint { Latitude = 51.5074, Longitude = -0.1278 } },
                new CityLocation { CityName = "Paris", WeatherRequestPoint = new WeatherRequestPoint { Latitude = 48.8566, Longitude = 2.3522 } },
                new CityLocation { CityName = "Bucharest", WeatherRequestPoint = new WeatherRequestPoint { Latitude = 44.4268, Longitude = 26.1025 } }
            };
            OpenMeteoRequestHandler = openMeteoRequestHandler;
        }

        public async Task GetWeatherForCity()
        {
            if (SelectedCity != null)
            {
                WeatherDataList.Clear();
                SelectedWeatherItem.Clear();
                WeatherDataList = await OpenMeteoRequestHandler.GetWeatherDataForLocation(SelectedCity.WeatherRequestPoint);
                SelectedWeatherItem = new List<WeatherData>() { WeatherDataList.FirstOrDefault() };
            }
        }

        public async Task Initialize()
        {
            SelectedCity = CityLocations[0];
            await GetWeatherForCity();
        }

    }
}
