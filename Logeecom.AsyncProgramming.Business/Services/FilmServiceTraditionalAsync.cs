using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Business.Models;
using Logeecom.AsyncProgramming.Domain;
using System.Diagnostics;

namespace Logeecom.AsyncProgramming.Business.Services
{
    public class FilmServiceTraditionalAsync
    {
        private readonly IFilmRepositorySync filmRepository;
        private readonly IActorRepositorySync actorRepository;
        private readonly IAwardRepositorySync awardRepository;
        private readonly IDirectorRepositorySync directorRepository;
        private readonly IGenreRepositorySync genreRepository;

        public FilmServiceTraditionalAsync(
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
                Mutex mutex = new();

                foreach (FilmViewModel film in films)
                {
                    if (this.filmRepository.GetFilmByName(film.Name) != null)
                    {
                        continue;
                    }

                    Genre? genre = null;
                    Thread genreThread = new(() => this.CheckGenre(film, out genre, mutex));
                    genreThread.Start();

                    Award? award = null;
                    Thread awardThread = new(() => this.CheckAward(film, out award, mutex));
                    awardThread.Start();

                    Director? director = null;
                    Thread directorThread = new(() => this.CheckDirector(film, out director, mutex));
                    directorThread.Start();

                    List<Actor>? actors = null;
                    Thread actorsThread = new(() => this.CheckActors(film, out actors, mutex));
                    actorsThread.Start();

                    genreThread.Join();
                    awardThread.Join();
                    directorThread.Join();
                    actorsThread.Join();

                    Film newFilm = new(Guid.NewGuid(), film.Name, film.Year, film.Country, genre.Id, director.Id, award.Id);
                    newFilm.SetActors(actors);

                    this.filmRepository.AddFilm(newFilm);
                }
                this.filmRepository.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void CheckActors(FilmViewModel film, out List<Actor> actors, Mutex mutex)
        {
            mutex.WaitOne();

            actors = new();
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

            mutex.ReleaseMutex();
        }

        private void CheckDirector(FilmViewModel film, out Director? director, Mutex mutex)
        {
            mutex.WaitOne();

            director = this.directorRepository.GetDirectorByName(film.Director);
            if (director is null)
            {
                director = new Director(Guid.NewGuid(), film.Director);
                this.directorRepository.AddDirector(director);
            }
            else
            {
                director.IncerementFilms();
            }

            mutex.ReleaseMutex();
        }

        private void CheckAward(FilmViewModel film, out Award? award, Mutex mutex)
        {
            mutex.WaitOne();

            award = this.awardRepository.GetAwardByName(film.Award);
            if (award is null)
            {
                award = new Award(Guid.NewGuid(), film.Award);
                this.awardRepository.AddAward(award);
            }

            mutex.ReleaseMutex();
        }

        private void CheckGenre(FilmViewModel film, out Genre? genre, Mutex mutex)
        {
            mutex.WaitOne();

            genre = this.genreRepository.GetGenreByName(film.Genre);
            if (genre is null)
            {
                genre = new Genre(Guid.NewGuid(), film.Genre);
                this.genreRepository.AddGenre(genre);
            }

            mutex.ReleaseMutex();
        }
    }
}