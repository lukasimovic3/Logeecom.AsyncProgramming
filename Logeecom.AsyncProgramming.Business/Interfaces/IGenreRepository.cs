using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IGenreRepository
    {
        public Genre? GetGenreByName(string name);

        public void AddGenre(Genre genre);
    }
}