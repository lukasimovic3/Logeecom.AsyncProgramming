using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class DirectorRepository
    {
        private readonly DbContextEF context;

        public DirectorRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Director director)
        {
            return this.context.Directors.AddAsync(director).AsTask();
        }

        public Task SaveChanges()
        {
            Thread.Sleep(10);
            return this.context.SaveChangesAsync();
        }

        public Task<Director?> GetByDirectorNameAsync(string name)
        {
            return this.context.Directors.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}