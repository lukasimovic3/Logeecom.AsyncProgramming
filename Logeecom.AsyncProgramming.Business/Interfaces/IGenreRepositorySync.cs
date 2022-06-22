using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IGenreRepositorySync
    {
        public Genre? GetGenreByName(string name);

        public void AddGenre(Genre genre);
    }
}