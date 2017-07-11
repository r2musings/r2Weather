using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using r2weathernet.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace r2weathernet.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private AppSettings _appSettings;

        public WeatherController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet("[action]/{zip}")]
        public async Task<IActionResult> Zip(string zip)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_appSettings.WeatherDataUrl);
                    var response = await client.GetAsync($"/by-zip/{zip}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    if (weather.Weather == null || weather.Main == null)
                    {
                        return NotFound(new { Error = weather.Message });
                    }

                    var result = new WeatherResult(weather);
                    result.Zip = zip;
                    return Ok(result);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }
    }
}