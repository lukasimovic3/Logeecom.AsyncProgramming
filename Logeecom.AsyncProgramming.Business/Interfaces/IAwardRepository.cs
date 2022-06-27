using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IAwardRepository
    {
        public Task CreateAsync(Award award);

        public Task<Award?> GetByAwardNameAsync(string name);
    }
}