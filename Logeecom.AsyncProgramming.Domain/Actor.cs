namespace Logeecom.AsyncProgramming.Domain
{
    public class Actor
    {
        public Actor(Guid id, string name)
        {
            Id = id;
            Name = name;
            Film_count = 1;
            Films = new();
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Film_count { get; private set; }

        public List<Film> Films { get; private set; }

        public void IncerementFilms()
        {
            this.Film_count++;
        }
    }
}