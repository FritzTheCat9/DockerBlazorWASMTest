using Microsoft.EntityFrameworkCore;

namespace DockerBlazorWASMTest.Api
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            modelBuilder.Entity<WeatherForecast>().HasData(new List<WeatherForecast>()
            {
                new() {
                    Id = 1,
                    Date = DateTime.UtcNow.Date.AddDays(1).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 2,
                    Date = DateTime.UtcNow.Date.AddDays(2).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 3,
                    Date = DateTime.UtcNow.Date.AddDays(3).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 4,
                    Date = DateTime.UtcNow.Date.AddDays(4).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 5,
                    Date = DateTime.UtcNow.Date.AddDays(5).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 6,
                    Date = DateTime.UtcNow.Date.AddDays(6).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 7,
                    Date = DateTime.UtcNow.Date.AddDays(7).Date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
            });
        }
    }
}
