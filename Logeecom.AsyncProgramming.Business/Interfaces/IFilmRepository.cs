using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IFilmRepository
    {
        public Task CreateAsync(Film film);

        public Task<Film?> GetByFilmNameAsync(string name);

        public Task SaveChanges();
    }
}