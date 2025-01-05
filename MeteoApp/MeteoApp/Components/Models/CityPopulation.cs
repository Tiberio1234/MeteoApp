﻿namespace MeteoApp.Components.Models
{
    public class CityPopulation
    {
        public string CityName { get; set; } = string.Empty;
        public double PupulationInMillions { get; set; }
        public double ForeignVisitorsInMillions { get; set; }
        public double CityBeautyPercentage { get; set; }
    }
}
