using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class FilmRepositorySync : IFilmRepositorySync
    {
        private readonly DbContextEF context;

        public FilmRepositorySync(DbContextEF context)
        {
            this.context = context;
        }

        public void AddFilm(Film film)
        {
            Thread.Sleep(100);
            this.context.Films.Add(film);
        }

        public void DeleteAll()
        {
            this.context.Genres.RemoveRange(this.context.Genres.ToList());
            this.context.Actors.RemoveRange(this.context.Actors.ToList());
            this.context.Directors.RemoveRange(this.context.Directors.ToList());
            this.context.Awards.RemoveRange(this.context.Awards.ToList());
            this.context.Films.RemoveRange(this.context.Films.ToList());
            this.context.SaveChanges();
        }

        public Film? GetFilmByName(string name)
        {
            Thread.Sleep(100);
            return this.context.Films.FirstOrDefault(f => f.Name == name);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}