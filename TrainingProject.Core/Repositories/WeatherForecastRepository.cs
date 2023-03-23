using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainingProject.Core.Repositories
{
    internal interface IWeatherForecastRepository
    {
        IList<Models.WeatherForecast> Get();
    }
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private TrainingProjectDbContext DbContext { get; }
        public WeatherForecastRepository(TrainingProjectDbContext dbContext)
        {
            DbContext = dbContext;
        }
            
        public IList<Models.WeatherForecast> Get()
        {
            var entities = DbContext.WeatherForecasts.Include(w => w.Temperature).ToList();
            return entities.Select(MapToModel).ToList();
        }

        public Models.WeatherForecast MapToModel(Entities.WeatherForecast entity)
        {
            return new Models.WeatherForecast
            {
                Id = entity.Id,
                Date = entity.Date,
                Summary = entity.Summary,
                Type = entity.Type,
                Temperature = entity.Temperature != null ? new Models.Temperature
                {
                    TemperatureC = entity.Temperature.TemperatureC,
                    TemperatureF = entity.Temperature.TemperatureF,
                } : null
            };
        }
    }
}
