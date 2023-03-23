using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Core.Repositories
{
    internal class TrainingProjectDbContext : DbContext
    {
        public TrainingProjectDbContext(DbContextOptions options)
            : base(options)
        {
           
        }

        public DbSet<Entities.Information> Information { get; set; }
        public DbSet<Entities.WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Entities.Temperature> Temperatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Temperature>().HasData(new Entities.Temperature { Id = 1, TemperatureC = "33" });
            modelBuilder.Entity<Entities.Temperature>().HasData(new Entities.Temperature { Id = 2, TemperatureC = "34" });
            modelBuilder.Entity<Entities.Temperature>().HasData(new Entities.Temperature { Id = 3, TemperatureC = "35" });
            modelBuilder.Entity<Entities.Temperature>().HasData(new Entities.Temperature { Id = 4, TemperatureC = "36" });
            modelBuilder.Entity<Entities.Temperature>().HasData(new Entities.Temperature { Id = 5, TemperatureC = "37" });

            modelBuilder.Entity<Entities.WeatherForecast>().HasData(new Entities.WeatherForecast { Id = 1, TemperatureId = 1, Date = new DateTime(2020,02,03), Summary = "Cold", Type = "1" });
            modelBuilder.Entity<Entities.WeatherForecast>().HasData(new Entities.WeatherForecast { Id = 2, Date = new DateTime(2020, 02, 04), Summary = "Mild", Type = "0" });
            modelBuilder.Entity<Entities.WeatherForecast>().HasData(new Entities.WeatherForecast { Id = 3, TemperatureId = 3, Date = new DateTime(2020, 02, 05), Summary = "Warm", Type = "1" });
            modelBuilder.Entity<Entities.WeatherForecast>().HasData(new Entities.WeatherForecast { Id = 4, TemperatureId = 4, Date = new DateTime(2020, 02, 06), Summary = "Balmy", Type = "0" });
            modelBuilder.Entity<Entities.WeatherForecast>().HasData(new Entities.WeatherForecast { Id = 5, TemperatureId = 5, Date = new DateTime(2020, 02, 07), Summary = "Hot", Type = "1" });
        }
    }
}
