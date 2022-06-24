using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class GenreRepository
    {
        private readonly DbContextEF context;

        public GenreRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Genre genre)
        {
            return this.context.Genres.AddAsync(genre).AsTask();
        }

        public Task SaveChanges()
        {
            Thread.Sleep(10);
            return this.context.SaveChangesAsync();
        }

        public Task<Genre?> GetByGenreNameAsync(string name)
        {
            return this.context.Genres.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}