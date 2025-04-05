using Microsoft.AspNetCore.Http.HttpResults;
using SimpleApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Tests
{
    public class WeatherEndpointsTests
    {
        [Fact]
        public void GetWeatherForecast_ReturnsFiveForecasts()
        {
            // Act
            var result = WeatherEndpoints.GetWeatherForecast();

            // Assert
            Assert.Equal(5, result.Length);
        }

        [Fact]
        public void GetWeatherForecastById_ReturnsOkForValidId()
        {
            // Arrange
            int validId = 3;

            // Act
            var result = WeatherEndpoints.GetWeatherForecastById(validId);

            // Assert
            Assert.IsType<Ok<WeatherForecast>>(result);
        }

        [Fact]
        public void GetWeatherForecastById_ReturnsBadRequestForInvalidId()
        {
            // Arrange
            int invalidId = -10;

            // Act
            var result = WeatherEndpoints.GetWeatherForecastById(invalidId);

            // Assert
            Assert.IsType<BadRequest<string>>(result);
        }
    }
}
