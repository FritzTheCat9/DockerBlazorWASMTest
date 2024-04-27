using DockerBlazorWASMTest.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
var frontendUrl = builder.Configuration.GetValue<string>("FrontendUrl");
var policyName = "MyCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, policy =>
    {
        policy.WithOrigins(frontendUrl)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithExposedHeaders("Content-Disposition");
    });
});

// Database
var connectionString = builder.Configuration.GetValue<string>("ConnectionString");

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseNpgsql(connectionString);
});

builder.Services.AddHostedService<DatabaseInitializer>();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DockerBlazorWASMTest.Api");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGet("/weatherforecast", (AppDbContext dbContext) =>
{
    var forecasts = dbContext.WeatherForecasts.ToList();
    return forecasts;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// Cors
app.UseCors(policyName);

app.Run();
