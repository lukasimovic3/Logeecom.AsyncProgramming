using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IActorRepositorySync
    {
        public Actor? GetActorByName(string name);

        public void AddActor(Actor actor);
    }
}