using System;

namespace TrainingProject.Core.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; }

        public string Summary { get; set; }

        public string Type { get; set; }
    }  
}
