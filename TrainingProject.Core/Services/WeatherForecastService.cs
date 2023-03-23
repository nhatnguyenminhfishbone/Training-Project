using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Core.Models;
using TrainingProject.Core.Repositories;

namespace TrainingProject.Core.Services
{
    public interface IWeatherForecastService
    {
        IList<Models.WeatherForecast> Get();
    }
    internal class WeatherForecastService : IWeatherForecastService
    {
        IWeatherForecastRepository WeatherForecastRepository;
        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            WeatherForecastRepository = weatherForecastRepository;
        }
        public IList<WeatherForecast> Get()
        {
            return WeatherForecastRepository.Get();
        }
    }
}
