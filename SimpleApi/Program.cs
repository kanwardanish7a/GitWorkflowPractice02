using SimpleApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Weather forecast endpoints
var weatherApi = app.MapGroup("/weatherforecast");
weatherApi.MapGet("/", WeatherEndpoints.GetWeatherForecast)
          .WithName("GetWeatherForecast")
          .WithOpenApi();
weatherApi.MapGet("/{id}", WeatherEndpoints.GetWeatherForecastById)
          .WithName("GetWeatherForecastById")
          .WithOpenApi();

app.MapGet("/lovemessage", WeatherEndpoints.GetLoveMessage);

app.Run();

// Make the WeatherForecast record accessible to tests
public partial record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}