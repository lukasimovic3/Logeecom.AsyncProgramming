using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IFilmRepositorySync
    {
        public void AddFilm(Film film);

        public IDbContextTransaction BeginTransaction();

        void DeleteAll();

        public Film? GetFilmByName(string name);
    }
}