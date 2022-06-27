using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IGenreRepository
    {
        public Task CreateAsync(Genre genre);

        public Task<Genre?> GetByGenreNameAsync(string name);
    }
}