using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DbContextEF context;

        public DirectorRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Director director)
        {
            Thread.Sleep(100);
            return this.context.Directors.AddAsync(director).AsTask();
        }

        public Task<Director?> GetByDirectorNameAsync(string name)
        {
            Thread.Sleep(100);
            return this.context.Directors.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}