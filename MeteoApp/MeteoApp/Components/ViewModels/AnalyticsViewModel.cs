using MeteoApp.Components.Models;

namespace MeteoApp.Components.ViewModels
{
    public class AnalyticsViewModel
    {
        public List<CityPopulation> CityPopulationDataItem { get; }

        public AnalyticsViewModel()
        {
            CityPopulationDataItem = new List<CityPopulation>();
        }

        public void LoadData()
        {
            CityPopulationDataItem.Clear();
            CityPopulationDataItem.Add(new CityPopulation { CityName = "Rome", PupulationInMillions = 4.3, CityBeautyPercentage = 85, ForeignVisitorsInMillions = 15.2 });
            CityPopulationDataItem.Add(new CityPopulation { CityName = "Bucharest", PupulationInMillions = 1.8, CityBeautyPercentage = 70, ForeignVisitorsInMillions = 1.1 });
            CityPopulationDataItem.Add(new CityPopulation { CityName = "Paris", PupulationInMillions = 2.1, CityBeautyPercentage = 90, ForeignVisitorsInMillions = 25.9 });
            CityPopulationDataItem.Add(new CityPopulation { CityName = "London", PupulationInMillions = 8.9, CityBeautyPercentage = 75, ForeignVisitorsInMillions = 20.0 });

        }

    }
}
