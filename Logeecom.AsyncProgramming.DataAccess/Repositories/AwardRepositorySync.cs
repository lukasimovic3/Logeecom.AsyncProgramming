using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class AwardRepositorySync : IAwardRepositorySync
    {
        private readonly DbContextEF context;

        public AwardRepositorySync(DbContextEF context)
        {
            this.context = context;
        }

        public Award? GetAwardByName(string name)
        {
            Thread.Sleep(100);
            return this.context.Awards.FirstOrDefault(a => a.Name == name);
        }

        public void AddAward(Award award)
        {
            Thread.Sleep(100);
            this.context.Awards.Add(award);
        }
    }
}