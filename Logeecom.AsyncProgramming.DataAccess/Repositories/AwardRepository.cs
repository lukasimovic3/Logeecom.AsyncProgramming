using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class AwardRepository
    {
        private readonly DbContextEF context;

        public AwardRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Award award)
        {
            return this.context.Awards.AddAsync(award).AsTask();
        }

        public Task SaveChanges()
        {
            Thread.Sleep(10);
            return this.context.SaveChangesAsync();
        }

        public Task<Award?> GetByAwardNameAsync(string name)
        {
            return this.context.Awards.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}