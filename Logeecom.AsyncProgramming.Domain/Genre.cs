namespace Logeecom.AsyncProgramming.Domain
{
    public class Genre
    {
        public Genre(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public List<Film>? Films { get; private set; }
    }
}