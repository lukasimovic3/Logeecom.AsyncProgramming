using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class DirectorRepositorySync : IDirectorRepositorySync
    {
        private readonly DbContextEF context;

        public DirectorRepositorySync(DbContextEF context)
        {
            this.context = context;
        }

        public Director? GetDirectorByName(string name)
        {
            Thread.Sleep(10);
            return this.context.Directors.FirstOrDefault(d => d.Name == name);
        }

        public void AddDirector(Director director)
        {
            Thread.Sleep(10);
            this.context.Directors.Add(director);
            this.context.SaveChanges();
        }
    }
}