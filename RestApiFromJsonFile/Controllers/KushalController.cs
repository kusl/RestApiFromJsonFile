using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RestApiFromJsonFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KushalController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public KushalController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Kushal> Get()
        {
            _logger.LogInformation("Get Kushal");

            string path = @"kushal.json";
            Kushal? kushal = new Kushal();
            if (System.IO.File.Exists(path))
            {
                using StreamReader streamReader = new StreamReader(path);
                string kushalText = await streamReader.ReadToEndAsync();
                kushal = JsonConvert.DeserializeObject<Kushal>(kushalText);
            }

            if (kushal == null)
            {
                return new Kushal() { Id = 0, Name = "", Latitude = 0, Longitude = 0 };
            }

            return kushal;
        }
    }
}