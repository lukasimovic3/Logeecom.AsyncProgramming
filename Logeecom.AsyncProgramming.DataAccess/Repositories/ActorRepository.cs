using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess.Repositories
{
    public class ActorRepository
    {
        private readonly DbContextEF context;

        public ActorRepository(DbContextEF context)
        {
            this.context = context;
        }

        public Task CreateAsync(Actor actor)
        {
            Thread.Sleep(100);
            return this.context.Actors.AddAsync(actor).AsTask();
        }

        public Task<Actor?> GetByActorName(string name)
        {
            Thread.Sleep(100);
            return this.context.Actors.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task SaveChanges()
        {
            return this.context.SaveChangesAsync();
        }

        public void DeleteAllAsync()
        {
            this.context.Films.RemoveRange(this.context.Films.ToList());
            this.context.Actors.RemoveRange(this.context.Actors.ToList());
            this.context.Awards.RemoveRange(this.context.Awards.ToList());
            this.context.Directors.RemoveRange(this.context.Directors.ToList());
            this.context.Genres.RemoveRange(this.context.Genres.ToList());
        }
    }
}