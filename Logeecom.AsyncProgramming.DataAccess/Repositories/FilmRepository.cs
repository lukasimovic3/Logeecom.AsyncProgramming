using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class FilmRepository
    {
        private readonly DbContextEF context;

        public FilmRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Film film)
        {
            Thread.Sleep(100);
            return this.context.Films.AddAsync(film).AsTask();
        }

        public Task SaveChanges()
        {
            return this.context.SaveChangesAsync();
        }

        public Task<Film?> GetByFilmNameAsync(string name)
        {
            Thread.Sleep(100);
            return this.context.Films.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}