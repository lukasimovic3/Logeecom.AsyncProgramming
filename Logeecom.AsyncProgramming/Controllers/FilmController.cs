using Logeecom.AsyncProgramming.Business.Dtos;
using Logeecom.AsyncProgramming.Business.Services;
using Logeecom.AsyncProgramming.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logeecom.AsyncProgramming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        [HttpPost("load")]
        public async Task<Response> LoadFilms(List<FilmDto> films, [FromServices] FilmService service)
        {
            await service.LoadFilms(films);

            return new()
            {
            };
        }

        [HttpGet("delete")]
        public async Task<Response> DeleteFilms([FromServices] FilmService service)
        {
            await service.DeleteAll();

            return new()
            {
            };
        }
    }
}