using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController, Route("api/[controller]")]
    [Consumes("application/json")]
    public class Weather : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWeather(string city, int daysCount) {
            if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city))
                return BadRequest("city is not provided");
            if (daysCount < 0 || daysCount > 16)
                return BadRequest("incorrect days count requested");
            WorkerApp.WeatherClass weather = new WorkerApp.WeatherClass();
            bool isSuccessRequest;
            var result = weather.getWeather(city, daysCount, out isSuccessRequest);
            if (isSuccessRequest)
                BadRequest("unexpected error occured.");
            return Ok(result);
        }
    }
}
