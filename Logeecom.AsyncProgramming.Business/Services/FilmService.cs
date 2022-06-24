using Logeecom.AsyncProgramming.Business.Dtos;
using Logeecom.AsyncProgramming.DataAccess.Repositories;
using Logeecom.AsyncProgramming.Domain;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace Logeecom.AsyncProgramming.Business.Services
{
    public class FilmService
    {
        private readonly ActorRepository actorRepository;
        private readonly AwardRepository awardRepository;
        private readonly DirectorRepository directorRepository;
        private readonly FilmRepository filmRepository;
        private readonly GenreRepository genreRepository;

        public FilmService(
            ActorRepository actorRepository,
            AwardRepository awardRepository,
            DirectorRepository directorRepository,
            FilmRepository filmRepository,
            GenreRepository genreRepository)
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
                List<Actor> actors = new();
                Award award = await this.awardRepository.GetByAwardNameAsync(film.Award);
                Director director = await this.directorRepository.GetByDirectorNameAsync(film.Director);
                Genre genre = await this.genreRepository.GetByGenreNameAsync(film.Genre);

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

                if (award is null)
                {
                    award = new(Guid.NewGuid(), film.Award);
                    await this.awardRepository.CreateAsync(award);
                }

                if (director is null)
                {
                    director = new(Guid.NewGuid(), film.Director);
                    await this.directorRepository.CreateAsync(director);
                }
                else
                {
                    director.IncrementFilms();
                }

                if (genre is null)
                {
                    genre = new(Guid.NewGuid(), film.Genre);
                    await this.genreRepository.CreateAsync(genre);
                }

                Film newFilm = new(Guid.NewGuid(), film.Name, film.Year, film.Country, genre.Id, director.Id, award.Id);
                newFilm.AddActors(actors);

                await this.filmRepository.CreateAsync(newFilm);

                await this.filmRepository.SaveChanges();
            }
        }

        public async Task DeleteAll()
        {
            this.actorRepository.DeleteAllAsync();
            await this.actorRepository.SaveChanges();
        }
    }

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}