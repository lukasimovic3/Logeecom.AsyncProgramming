using Logeecom.AsyncProgramming.Business.Dtos;
using Logeecom.AsyncProgramming.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logeecom.AsyncProgramming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        [HttpPost("load")]
        public async Task<string> LoadFilms(List<FilmDto> films, [FromServices] FilmService service)
        {
            System.Diagnostics.Stopwatch? watch = new();

            watch.Start();

            await service.LoadFilms(films);

            watch.Stop();

            return $"Execution Time: {watch.ElapsedMilliseconds} ms";
        }

        [HttpDelete("delete")]
        public async Task DeleteFilms([FromServices] FilmService service)
        {
            await service.DeleteAll();
        }
    }
}