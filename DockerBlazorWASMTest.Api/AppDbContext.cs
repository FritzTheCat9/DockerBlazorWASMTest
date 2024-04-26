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
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 2,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 3,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 4,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 5,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 6,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(6)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
                new() {
                    Id = 7,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                },
            });
        }
    }
}
