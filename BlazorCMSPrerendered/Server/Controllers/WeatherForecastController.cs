using BlazorCMS.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCMSPrerendered.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherService)
        {
            _logger = logger;
            _weatherForecastService = weatherService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _weatherForecastService.GetForecastAsync();
        }
    }
}