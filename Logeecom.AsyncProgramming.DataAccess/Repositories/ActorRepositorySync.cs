using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class ActorRepositorySync : IActorRepositorySync
    {
        private readonly DbContextEF context;

        public ActorRepositorySync(DbContextEF context)
        {
            this.context = context;
        }

        public Actor? GetActorByName(string name)
        {
            Thread.Sleep(10);
            return this.context.Actors.FirstOrDefault(a => a.Name == name);
        }

        public void AddActor(Actor actor)
        {
            Thread.Sleep(10);
            this.context.Actors.Add(actor);
            this.context.SaveChanges();
        }
    }
}