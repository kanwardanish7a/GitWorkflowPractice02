namespace SimpleApi
{
    public static class WeatherEndpoints
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public static WeatherForecast[] GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .ToArray();
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
