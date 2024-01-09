using Microsoft.AspNetCore.Mvc;

namespace DemoAPIDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private IEmployee _employee;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmployee employee)
        {
            _logger = logger;
            _employee = employee;   
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _employee.Name = "Patna";
            _employee.Address = "Sharsa";
            _employee.Age = 23;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                City = _employee.Name,
                Address = _employee.Address,
               Age = _employee.Age,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}