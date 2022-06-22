namespace Logeecom.AsyncProgramming.Domain
{
    public class Director
    {
        public Director(Guid id, string name)
        {
            Id = id;
            Name = name;
            CountFilms = 0;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int CountFilms { get; private set; }

        public List<Film>? Films { get; private set; }
    }
}