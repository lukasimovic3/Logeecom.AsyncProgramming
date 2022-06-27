using Logeecom.AsyncProgramming.Business.Models;
using Logeecom.AsyncProgramming.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logeecom.AsyncProgramming.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly FilmServiceTraditionalAsync filmService;

        public FilmController(FilmServiceTraditionalAsync filmService)
        {
            this.filmService = filmService;
        }

        [HttpPost]
        public string AddFilms(List<FilmViewModel> films)
        {
            System.Diagnostics.Stopwatch? watch = new();

            watch.Start();

            this.filmService.CreateFilms(films);

            watch.Stop();

            return $"Execution Time: {watch.ElapsedMilliseconds} ms";
        }

        [HttpDelete]
        public void DeleteAll()
        {
            this.filmService.DeleteAll();
        }
    }
}