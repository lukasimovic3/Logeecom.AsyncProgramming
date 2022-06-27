using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IActorRepository
    {
        public Task CreateAsync(Actor actor);

        public Task<Actor?> GetByActorName(string name);

        public void DeleteAllAsync();
    }
}