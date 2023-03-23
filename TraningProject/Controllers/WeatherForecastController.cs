using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainingProject.Core.Models;
using TrainingProject.Core.Services;

namespace TraningProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        IWeatherForecastService WeatherForecastService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            WeatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForecastService.Get();
        }
    }
}
