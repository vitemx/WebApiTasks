using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
        .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("Get/weatherforescast")]
    // [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("La API Retorna la lista de weatherforecast");
        return ListWeatherForecast;
    }

    [HttpPost(Name = "SaveWeatherForecast")]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete(Name = "DeleteWeatherForecast")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}