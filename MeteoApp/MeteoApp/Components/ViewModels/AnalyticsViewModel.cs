using MeteoApp.Components.Models;

namespace MeteoApp.Components.ViewModels
{
    public class AnalyticsViewModel
    {
        public List<CityPopulation> CityPopulationDataItem { get; }

        public AnalyticsViewModel()
        {
            CityPopulationDataItem = new List<CityPopulation>();
            LoadData();
        }

        public void LoadData()
        {
            CityPopulationDataItem.Clear();

            // Rome data with foreign visitors data for the years 2021 to 2024
            CityPopulationDataItem.Add(new CityPopulation
            {
                CityName = "Rome",
                PupulationInMillions = 4.3,
                CityBeautyPercentage = 85,
                ForeignVisitorsInMillions = new List<VisitorsByYear>
                {
                    new VisitorsByYear { Year = "2021", VisitorsInMillions = 9.5 },
                    new VisitorsByYear { Year = "2022", VisitorsInMillions = 9.8 },
                    new VisitorsByYear { Year = "2023", VisitorsInMillions = 9.9 },
                    new VisitorsByYear { Year = "2024", VisitorsInMillions = 10.0 }, // Estimated number for 2024
                }
            });

            // Bucharest data with foreign visitors data for the years 2021 to 2024
            CityPopulationDataItem.Add(new CityPopulation
            {
                CityName = "Bucharest",
                PupulationInMillions = 1.8,
                CityBeautyPercentage = 70,
                ForeignVisitorsInMillions = new List<VisitorsByYear>
                   {
                       new VisitorsByYear { Year = "2021", VisitorsInMillions = 0.9 },
                       new VisitorsByYear { Year = "2022", VisitorsInMillions = 1.0 },
                       new VisitorsByYear { Year = "2023", VisitorsInMillions = 1.05 },
                       new VisitorsByYear { Year = "2024", VisitorsInMillions = 1.1 }, // Estimated number for 2024
                   }
            });

            // Paris data with foreign visitors data for the years 2021 to 2024
            CityPopulationDataItem.Add(new CityPopulation
            {
                CityName = "Paris",
                PupulationInMillions = 2.1,
                CityBeautyPercentage = 90,
                ForeignVisitorsInMillions = new List<VisitorsByYear>
                    {
                        new VisitorsByYear { Year = "2021", VisitorsInMillions = 24.0 },
                        new VisitorsByYear { Year = "2022", VisitorsInMillions = 25.0 },
                        new VisitorsByYear { Year = "2023", VisitorsInMillions = 25.5 },
                        new VisitorsByYear { Year = "2024", VisitorsInMillions = 26.0 }, // Estimated number for 2024
                    }
            });

            // London data with foreign visitors data for the years 2021 to 2024
            CityPopulationDataItem.Add(new CityPopulation
            {
                CityName = "London",
                PupulationInMillions = 8.9,
                CityBeautyPercentage = 75,
                ForeignVisitorsInMillions = new List<VisitorsByYear>
                     {
                         new VisitorsByYear { Year = "2021", VisitorsInMillions = 18.0 },
                         new VisitorsByYear { Year = "2022", VisitorsInMillions = 19.0 },
                         new VisitorsByYear { Year = "2023", VisitorsInMillions = 19.5 },
                         new VisitorsByYear { Year = "2024", VisitorsInMillions = 20.0 }, // Estimated number for 2024
                     }
            });
        }


    }
}
