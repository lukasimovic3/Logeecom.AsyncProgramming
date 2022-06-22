using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IDirectorRepositorySync
    {
        public Director? GetDirectorByName(string name);

        public void AddDirector(Director director);
    }
}