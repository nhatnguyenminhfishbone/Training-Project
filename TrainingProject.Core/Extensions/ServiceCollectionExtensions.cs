using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingProject.Core.Repositories;
using TrainingProject.Core.Services;

namespace TrainingProject.Core.Extensions
{

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTrainingProjectServices(this IServiceCollection services)
        {
            //services
            services.AddScoped<IInformationService, InformationService>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            //repositories
            services.AddScoped<IInformationRepository, InformationRepository>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            return services;
        }

        public static IServiceCollection AddTrainingProjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrainingProjectDbContext>((sp, optBuilder) =>
            {
                var connectionString = configuration.GetConnectionString("TrainingProject");
                optBuilder.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
