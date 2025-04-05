namespace SimpleApi
{
    public static class WeatherEndpoints
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public static IResult GetWeatherForecast()
        {
            var weatherForecasts = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .ToArray();

            // Return "HI I LOVE YOU" along with the weather forecast as a part of the response
            return Results.Ok(new
            {
                Message = "HI I LOVE YOU",
                Forecasts = weatherForecasts
            });
        }

        public static IResult GetWeatherForecastById(int id)
        {
            if (id < 0 || id >= Summaries.Length)
            {
                return Results.BadRequest("Invalid ID");
            }

            return Results.Ok(new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
                Random.Shared.Next(-20, 55),
                Summaries[id]
            ));
        }
    }
}
