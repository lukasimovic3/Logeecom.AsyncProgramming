using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IFilmRepository
    {
        public void AddFilm(Film film);

        void DeleteAll();

        public Film? GetFilmByName(string name);

        void SaveChanges();
    }
}