using MeteoServerProject.OpenMeteo;

namespace MeteoApp.Components.Models
{
    public class CityLocation
    {
        public string CityName { get; set; } = string.Empty;
        public WeatherRequestPoint WeatherRequestPoint { get; set; } = new WeatherRequestPoint();
    }
}
