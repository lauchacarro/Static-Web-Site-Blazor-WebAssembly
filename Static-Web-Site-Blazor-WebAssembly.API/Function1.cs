using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Static_Web_Site_Blazor_WebAssembly.Shared;

namespace Static_Web_Site_Blazor_WebAssembly.API
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "WeatherForecasts")] HttpRequest req,
            ILogger log)
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = new DateTime(2020, 05, 06),
                    TemperatureC = RandomTemperature(),
                    Summary ="Freezing"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 05, 07),
                    TemperatureC = RandomTemperature(),
                    Summary ="Bracing"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 05, 08),
                    TemperatureC = RandomTemperature(),
                    Summary ="Freezing"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 05, 09),
                    TemperatureC = RandomTemperature(),
                    Summary ="Balmy"
                },
                new WeatherForecast
                {
                    Date = new DateTime(2020, 05, 10),
                    TemperatureC = RandomTemperature(),
                    Summary ="Chilly"
                },
            };

            int RandomTemperature()
            {
                Random random = new Random();
                return random.Next(-20, 35);
            }

            return new OkObjectResult(weatherForecasts);
        }
    }
}
