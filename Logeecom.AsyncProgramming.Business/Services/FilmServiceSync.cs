using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Business.Models;
using Logeecom.AsyncProgramming.Domain;
using System.Diagnostics;

namespace Logeecom.AsyncProgramming.Business.Services
{
    public class FilmServiceSync
    {
        private static Mutex mutex = new Mutex();

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
                    if (this.filmRepository.GetFilmByName(film.Name) != null)
                    {
                        continue;
                    }

                    Genre? genre = null;
                    //this.CheckGenre(film, genre);
                    Thread genreThread = new Thread(() => this.CheckGenre(film, out genre, FilmServiceSync.mutex));
                    genreThread.Start();

                    FilmServiceSync.mutex.WaitOne();

                    Award? award = this.CheckAward(film);

                    Director? director = CheckDirector(film);

                    List<Actor> actors = CheckActors(film);

                    FilmServiceSync.mutex.ReleaseMutex();

                    genreThread.Join();

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

        private List<Actor> CheckActors(FilmViewModel film)
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

        private Director CheckDirector(FilmViewModel film)
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

        private Award CheckAward(FilmViewModel film)
        {
            Award? award = this.awardRepository.GetAwardByName(film.Award);
            if (award is null)
            {
                award = new Award(Guid.NewGuid(), film.Award);
                this.awardRepository.AddAward(award);
            }

            return award;
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