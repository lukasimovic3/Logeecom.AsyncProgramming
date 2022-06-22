using Logeecom.AsyncProgramming.Business.Models;
using Logeecom.AsyncProgramming.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logeecom.AsyncProgramming.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmSyncController : ControllerBase
    {
        private readonly FilmServiceSync filmService;

        public FilmSyncController(FilmServiceSync filmService)
        {
            this.filmService = filmService;
        }

        [HttpPost]
        public void AddFilms(List<FilmViewModel> films)
        {
            this.filmService.CreateFilms(films);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            this.filmService.DeleteAll();
        }
    }
}