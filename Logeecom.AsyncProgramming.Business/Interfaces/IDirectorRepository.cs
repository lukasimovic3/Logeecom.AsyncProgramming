using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IDirectorRepository
    {
        public Director? GetDirectorByName(string name);

        public void AddDirector(Director director);
    }
}