using Microsoft.AspNetCore.Mvc;

namespace Logeecom.AsyncProgramming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        [HttpGet]
        public List<WeatherForecast> Get()
        {
            return new()
            {
            };
        }
    }
}