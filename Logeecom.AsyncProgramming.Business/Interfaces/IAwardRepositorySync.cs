using Logeecom.AsyncProgramming.Domain;

namespace Logeecom.AsyncProgramming.Business.Interfaces
{
    public interface IAwardRepositorySync
    {
        public Award? GetAwardByName(string name);

        public void AddAward(Award award);
    }
}