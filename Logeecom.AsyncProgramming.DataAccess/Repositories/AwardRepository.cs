using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private readonly DbContextEF context;

        public AwardRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Award award)
        {
            Thread.Sleep(100);
            return this.context.Awards.AddAsync(award).AsTask();
        }

        public Task<Award?> GetByAwardNameAsync(string name)
        {
            Thread.Sleep(100);
            return this.context.Awards.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}