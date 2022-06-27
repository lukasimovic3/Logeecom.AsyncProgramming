using Logeecom.AsyncProgramming.Business.Interfaces;
using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DbContextEF context;

        public ActorRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Actor? GetActorByName(string name)
        {
            Thread.Sleep(100);
            return this.context.Actors.FirstOrDefault(a => a.Name == name);
        }

        public void AddActor(Actor actor)
        {
            Thread.Sleep(100);
            this.context.Actors.Add(actor);
        }
    }
}