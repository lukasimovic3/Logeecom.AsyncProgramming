using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DbContextEF context;

        public GenreRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Genre genre)
        {
            Thread.Sleep(100);
            return this.context.Genres.AddAsync(genre).AsTask();
        }

        public Task<Genre?> GetByGenreNameAsync(string name)
        {
            Thread.Sleep(100);
            return this.context.Genres.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}