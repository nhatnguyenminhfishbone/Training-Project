using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingProject.Core.Entities
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? TemperatureId { get; set; }
        [ForeignKey("TemperatureId")]
        public Temperature Temperature { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
    }
}
