using Microsoft.AspNetCore.Http.HttpResults;
using SimpleApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.MSTests
{
    [TestClass]
    public class WeatherEndpointsTests
    {
        [TestMethod]
        public void GetWeatherForecast_ReturnsFiveForecasts()
        {
            // Act
            var result = WeatherEndpoints.GetWeatherForecast();

            // Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void GetWeatherForecastById_ReturnsOkForValidId()
        {
            // Arrange
            int validId = 3;

            // Act
            var result = WeatherEndpoints.GetWeatherForecastById(validId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Ok<WeatherForecast>));
        }

        [TestMethod]
        public void GetWeatherForecastById_ReturnsBadRequestForInvalidId()
        {
            // Arrange
            int invalidId = 100;

            // Act
            var result = WeatherEndpoints.GetWeatherForecastById(invalidId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequest<string>));
        }
    }
}
