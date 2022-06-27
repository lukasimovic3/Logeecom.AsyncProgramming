using Logeecom.AsyncProgramming.Business.Dtos;
using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace Logeecom.AsyncProgramming.Business.Services
{
    public class FilmService
    {
        private readonly IActorRepository actorRepository;
        private readonly IAwardRepository awardRepository;
        private readonly IDirectorRepository directorRepository;
        private readonly IFilmRepository filmRepository;
        private readonly IGenreRepository genreRepository;

        public FilmService(
            IActorRepository actorRepository,
            IAwardRepository awardRepository,
            IDirectorRepository directorRepository,
            IFilmRepository filmRepository,
            IGenreRepository genreRepository)
        {
            this.actorRepository = actorRepository;
            this.awardRepository = awardRepository;
            this.directorRepository = directorRepository;
            this.filmRepository = filmRepository;
            this.genreRepository = genreRepository;
        }

        public async Task LoadFilms(List<FilmDto> request)
        {
            foreach (FilmDto film in request)
            {
                if (await CheckFilmWithSameNameExistsAsync(film) != null)
                {
                    continue;
                }

                Award award = await ResolveAward(film);
                Director director = await ResolveDirector(film);
                Genre genre = await ResolveGenre(film);
                List<Actor> actors = await ResolveActors(film);

                await this.filmRepository.CreateAsync(new Film(Guid.NewGuid(), film.Name, film.Year, film.Country, genre, director, award, actors));
            }
            await this.filmRepository.SaveChanges();
        }

        private Task<Film?> CheckFilmWithSameNameExistsAsync(FilmDto film)
        {
            return this.filmRepository.GetByFilmNameAsync(film.Name);
        }

        private async Task<Genre> ResolveGenre(FilmDto film)
        {
            Genre genre = await this.genreRepository.GetByGenreNameAsync(film.Genre);
            if (genre is null)
            {
                genre = new(Guid.NewGuid(), film.Genre);
                await this.genreRepository.CreateAsync(genre);
            }

            return genre;
        }

        private async Task<Director> ResolveDirector(FilmDto film)
        {
            Director director = await this.directorRepository.GetByDirectorNameAsync(film.Director);
            if (director is null)
            {
                director = new(Guid.NewGuid(), film.Director);
                await this.directorRepository.CreateAsync(director);
            }
            else
            {
                director.IncrementFilms();
            }

            return director;
        }

        private async Task<Award> ResolveAward(FilmDto film)
        {
            Award award = await this.awardRepository.GetByAwardNameAsync(film.Award);
            if (award is null)
            {
                award = new(Guid.NewGuid(), film.Award);
                await this.awardRepository.CreateAsync(award);
            }

            return award;
        }

        private async Task<List<Actor>> ResolveActors(FilmDto film)
        {
            List<Actor> actors = new();
            foreach (ActorDto actorDto in film.Actors)
            {
                Actor actor = await this.actorRepository.GetByActorName(actorDto.Name);
                if (actor is null)
                {
                    actor = new(Guid.NewGuid(), actorDto.Name);
                    await this.actorRepository.CreateAsync(actor);
                }
                else
                {
                    actor.IncrementFilms();
                }
                actors.Add(actor);
            }

            return actors;
        }

        public async Task DeleteAll()
        {
            this.actorRepository.DeleteAllAsync();
            await this.filmRepository.SaveChanges();
        }
    }

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}