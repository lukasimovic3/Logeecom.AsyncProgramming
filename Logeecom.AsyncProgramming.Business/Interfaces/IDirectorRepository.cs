using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IDirectorRepository
    {
        public Task CreateAsync(Director director);

        public Task<Director?> GetByDirectorNameAsync(string name);
    }
}