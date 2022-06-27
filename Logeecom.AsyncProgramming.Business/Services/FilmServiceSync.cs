using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Business.Models;
using Logeecom.AsyncProgramming.Domain;
using System.Diagnostics;

namespace Logeecom.AsyncProgramming.Business.Services
{
    public class FilmServiceSync
    {
        private readonly IFilmRepositorySync filmRepository;
        private readonly IActorRepositorySync actorRepository;
        private readonly IAwardRepositorySync awardRepository;
        private readonly IDirectorRepositorySync directorRepository;
        private readonly IGenreRepositorySync genreRepository;

        public FilmServiceSync(
            IFilmRepositorySync filmRepository,
            IActorRepositorySync actorRepository,
            IAwardRepositorySync awardRepository,
            IDirectorRepositorySync directorRepository,
            IGenreRepositorySync genreRepository)
        {
            this.filmRepository = filmRepository;
            this.actorRepository = actorRepository;
            this.awardRepository = awardRepository;
            this.directorRepository = directorRepository;
            this.genreRepository = genreRepository;
        }

        public void DeleteAll()
        {
            this.filmRepository.DeleteAll();
        }

        public void CreateFilms(List<FilmViewModel> films)
        {
            try
            {
                foreach (FilmViewModel film in films)
                {
                    if (CheckFilmWithSameNameExists(film))
                    {
                        continue;
                    }

                    Genre? genre = this.ResolveGenre(film);
                    Award? award = this.ResolveAward(film);
                    Director? director = this.ResolveDirector(film);
                    List<Actor> actors = this.ResolveActors(film);

                    Film newFilm = new
                        (Guid.NewGuid(), film.Name, film.Year, film.Country, genre, director, award, actors);
                    this.filmRepository.AddFilm(newFilm);
                }
                this.filmRepository.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private bool CheckFilmWithSameNameExists(FilmViewModel film)
        {
            return this.filmRepository.GetFilmByName(film.Name) != null;
        }

        private List<Actor> ResolveActors(FilmViewModel film)
        {
            List<Actor> actors = new();
            foreach (ActorViewModel actorItem in film.Actors)
            {
                Actor? actor = this.actorRepository.GetActorByName(actorItem.Name);
                if (actor is null)
                {
                    actor = new Actor(Guid.NewGuid(), actorItem.Name);
                    this.actorRepository.AddActor(actor);
                }
                else
                {
                    actor.IncerementFilms();
                }
                actors.Add(actor);
            }

            return actors;
        }

        private Director ResolveDirector(FilmViewModel film)
        {
            Director? director = this.directorRepository.GetDirectorByName(film.Director);
            if (director is null)
            {
                director = new Director(Guid.NewGuid(), film.Director);
                this.directorRepository.AddDirector(director);
            }
            else
            {
                director.IncerementFilms();
            }

            return director;
        }

        private Award ResolveAward(FilmViewModel film)
        {
            Award? award = this.awardRepository.GetAwardByName(film.Award);
            if (award is null)
            {
                award = new Award(Guid.NewGuid(), film.Award);
                this.awardRepository.AddAward(award);
            }

            return award;
        }

        private Genre ResolveGenre(FilmViewModel film)
        {
            Genre? genre = this.genreRepository.GetGenreByName(film.Genre);
            if (genre is null)
            {
                genre = new Genre(Guid.NewGuid(), film.Genre);
                this.genreRepository.AddGenre(genre);
            }

            return genre;
        }
    }
}