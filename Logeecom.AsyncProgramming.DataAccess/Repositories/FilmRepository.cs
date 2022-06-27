using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class FilmRepository : IFilmRepository
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

        public Task<Film?> GetByFilmNameAsync(string name)
        {
            Thread.Sleep(100);
            return this.context.Films.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task SaveChanges()
        {
            return this.context.SaveChangesAsync();
        }
    }
}